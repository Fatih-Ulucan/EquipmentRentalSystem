using System;
using EquipmentRentalSystem.Models;
using EquipmentRentalSystem.Services;

namespace EquipmentRentalSystem;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== UNIVERSITY EQUIPMENT RENTAL SYSTEM ===\n");

        RentalService service = new RentalService();

        User student1 = new Student("Fatih", "Ulucan");
        User employee1 = new Employee("Ahmet", "Yilmaz");
        
        service.AddUser(student1);
        service.AddUser(employee1);
        Console.WriteLine("------------------------------------------");

        Equipment laptop1 = new Laptop("Dell XPS 15", "Windows 11", 16);
        Equipment laptop2 = new Laptop("MacBook Pro", "macOS", 32);
        Equipment projector1 = new Projector("Epson 4K", "3840x2160", 4000);
        Equipment camera1 = new Camera("Sony A7 III", 24.2, true);

        service.AddEquipment(laptop1);
        service.AddEquipment(laptop2);
        service.AddEquipment(projector1);
        service.AddEquipment(camera1);
        Console.WriteLine("------------------------------------------");

        service.DisplayAvailableEquipment();
        Console.WriteLine("------------------------------------------");

        Console.WriteLine("\n[SCENARIO 1] Valid Rental:");
        service.RentEquipment(student1, laptop1, 5);

        Console.WriteLine("\n[SCENARIO 2] Invalid Rental (Not Available):");
        service.RentEquipment(employee1, laptop1, 3);

        Console.WriteLine("\n[SCENARIO 3] Invalid Rental (Limit Exceeded):");
        service.RentEquipment(student1, projector1, 2);
        service.RentEquipment(student1, camera1, 1);

        Console.WriteLine("\n[SCENARIO 4] Return on Time (No Penalty):");
        service.ReturnEquipment(student1, projector1, DateTime.Now.AddDays(1));

        Console.WriteLine("\n[SCENARIO 5] Late Return (With Penalty):");
        service.ReturnEquipment(student1, laptop1, DateTime.Now.AddDays(8));

        Console.WriteLine("\n--- FINAL SYSTEM STATE ---");
        service.DisplayAllEquipment();
    }
}