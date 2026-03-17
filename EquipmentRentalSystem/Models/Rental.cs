using System;

namespace EquipmentRentalSystem.Models;

public class Rental
{
    public User RentedBy { get; private set; }
    
    public Equipment RentedEquipment { get; private set; }
    
    public DateTime RentalDate { get; private set; }
    
    public DateTime DueDate { get; private set; }
    public decimal PenaltyFee { get; private set; }
    
    public DateTime? ReturnDate { get; private set; }

    public Rental(User user, Equipment equipment, int durationInDays)
    {
        RentedBy = user;
        RentedEquipment = equipment;
        RentalDate = DateTime.Now;
        DueDate = RentalDate.AddDays(durationInDays); 
        ReturnDate = null;
        PenaltyFee = 0;
    }

    public void CompleteRental(DateTime returnDate, decimal calculatedPenalty)
    {
        ReturnDate = returnDate;
        PenaltyFee = calculatedPenalty;
    }
}