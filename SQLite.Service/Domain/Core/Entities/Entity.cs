using SQLite.Service.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SQLite.Service.Domain.Core.Entities
{
    public enum EntityState
    {
        IsNewItem,
        IsEditedItem,
        IsDeletedItem,
    }
    public class Entity<T> : IEntity<T>, IEntity, INotifyPropertyChanged, IDataErrorInfo
    {
        public Entity()
        {

        }

        [PrimaryKey, AutoIncrement]
        public T Oid { get; set; }
        object IEntity.Oid { get => Oid; set => Oid = (T)value; }

        [Ignore]
        public EntityState State { get; set; }
        public string Error => string.Empty;

        public string this[string columnName] => string.Empty;

        public virtual bool Validate()
        {
            return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetPropertyValue<TProperty>(ref TProperty backingStore, TProperty value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<TProperty>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
