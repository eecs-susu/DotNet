using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Newtonsoft.Json.Linq;
using TankConstruction.Models.Base;
using TankConstruction.Models.SovietUnion;
using TankConstruction.Models.UnitedStates;
using TankConstruction.Models.Utils;

namespace TankConstruction
{
    public class Army<T> : List<T> where T : Tank
    {
        private readonly TankFactory _tankFactory;
        private readonly Random _random;
        
        public event EventHandler<ArmyChangedEventArgs> ArmyChanged;  
        public event EventHandler SortStarted;  
        public event EventHandler SortFinished;  
        public event EventHandler<SortItemPlacedEventArgs> SortItemPlaced;  
        public class SortItemPlacedEventArgs : EventArgs   
        {  
            public string Info { get; set; }
        }  
        public class ArmyChangedEventArgs : EventArgs   
        {  
            public string Info { get; set; }
        }  
        
        public DamageAllDelegate GetDamageForAll { get; set; }

        public Army(TankFactory tankFactory)
        {
            _tankFactory = tankFactory;
            _random = new Random(0);
        }

        public delegate uint DamageAllDelegate();

        public void DamageAll()
        {
            var dmg = GetDamageForAll();
            foreach (var item in this)
            {
                item.TakeDamage(dmg);
            }
        }

        public void AddCompositeTank()
        {
            Add((T) _tankFactory.CreateCompositeTank());
            OnArmyChanged(new ArmyChangedEventArgs
            {
                Info = "Added composite tank " + this.Last()
            });
        }

        public void AddLightTank()
        {
            Add((T) _tankFactory.CreateLightTank());
            OnArmyChanged(new ArmyChangedEventArgs
            {
                Info = "Added light tank " + this.Last()
            });
        }

        public void AddReactiveTank()
        {
            Add((T) _tankFactory.CreateReactiveTank());
            OnArmyChanged(new ArmyChangedEventArgs
            {
                Info = "Added reactive tank " + this.Last()
            });
        }

        public void AddRandomTank(uint n = 1)
        {
            for (int i = 0; i < n; ++i)
            {
                switch (_random.Next(0, 2))
                {
                    case 0:
                        AddCompositeTank();
                        break;
                    case 1:
                       AddLightTank();
                        break;
                    case 2:
                        AddReactiveTank();
                        break;
                }
            }
        }


        public string Serialize<TContainer>(Serializer<TContainer> serializer) where TContainer : SerializerContainer
        {
            var container = serializer.Create();
            container.Add("TankFactory", _tankFactory.GetType().Name);
            container.Add("Tanks", this);
            return container.Serialize();
        }

        public static Army<Tank> Deserialize<TContainer>(Serializer<TContainer> serializer, string data)
            where TContainer : SerializerContainer
        {
            var container = serializer.Create();
            container.Deserialize(data);
            Army<Tank> army = null;
            switch ((string) container.Container["TankFactory"])
            {
                case nameof(SovietUnionTankFactory):
                    army = new Army<Tank>(new SovietUnionTankFactory());
                    break;
                case nameof(UnitedStatesTankFactory):
                    army = new Army<Tank>(new UnitedStatesTankFactory());
                    break;
                default:
                    throw new Exception(); // TODO: make custom exception
            }

            foreach (var tank in (IEnumerable<JToken>) container.Container["Tanks"])
            {
                var type = (TankType) (int) tank["Type"];
                switch (type)
                {
                    case TankType.Composite:
                        army.AddCompositeTank();
                        break;
                    case TankType.Reactive:
                        army.AddReactiveTank();
                        break;
                    case TankType.Light:
                        army.AddLightTank();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return army;
        }

        protected virtual void OnArmyChanged(ArmyChangedEventArgs args)
        {
            ArmyChanged?.Invoke(this, args);
        }
        
        public Thread StartSort(Comparison<T> comparison)
        {
            OnSortStarted();
            var sortThread = new Thread(() =>
            {
                var used = this.Select(e => false).ToList();            
                var result = new List<T>();
                for (var i = 0; i < this.Count; ++i)
                {
                    var min = -1;
                    for (int j = 0; j < this.Count; j++)
                    {
                        if (min == -1 || (!used[j] && comparison(this[min], this[j]) < 0))
                        {
                            min = j;
                        }
                    }
                    
                    used[min] = true;
                    result.Add(this[min]);
                    OnSortItemPlaced(new SortItemPlacedEventArgs
                    {
                        Info = $"Sorted {i + 1} out of {this.Count}"
                    });
 
                    Thread.Sleep(1000);
                }
                this.Clear();
                foreach (var item in result)
                {
                    this.Add(item);
                }
                OnSortFinished();
            });
            sortThread.Start();
            return sortThread;
        }

        protected virtual void OnSortStarted()
        {
            SortStarted?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnSortFinished()
        {
            SortFinished?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnSortItemPlaced(SortItemPlacedEventArgs e)
        {
            SortItemPlaced?.Invoke(this, e);
        }
    }
}
