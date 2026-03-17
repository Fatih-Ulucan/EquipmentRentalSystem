using System;

namespace EquipmentRentalSystem.Models
{
    public abstract class Equipment 
    { 
        public string Id { get; private set; }
        public string Name { get; private set; }
        public bool IsAvailable {  get; private set; }

        protected Equipment(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            IsAvailable = true;
        }

        public void MarkAsAvailable()
        {
            IsAvailable = true;
        }
        
        public void MarkAsUnavailable()
        {
            IsAvailable = false;
        }
    }
}