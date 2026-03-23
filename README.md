# University Equipment Rental System

## Overview
This is an Object-Oriented console application developed in C# to manage university equipment rentals. The system separates domain models from the execution logic, adhering to clean code principles and the Single Responsibility Principle.

## Domain Models
* **Equipment (Abstract):** Base class for all rentable items.
  * `Laptop`: Includes Operating System and RAM size.
  * `Projector`: Includes Resolution and Brightness.
  * `Camera`: Includes Megapixels and Lens inclusion status.
* **User (Abstract):** Base class for system users.
  * `Student`: Limited to a maximum of 2 active rentals.
  * `Employee`: Limited to a maximum of 5 active rentals.
* **Rental:** Acts as the transaction record connecting Users and Equipment, tracking rental dates, due dates, and dynamically calculating penalty fees for late returns.

## Business Rules Implemented
1. **Availability Check:** Only equipment marked as `Available` can be rented.
2. **Rental Limits:** System strictly enforces maximum active rental limits based on user type.
3. **Penalty Calculation:** A penalty fee (50 units per day) is automatically calculated and applied upon late return.

## Architecture
The project utilizes a `RentalService` class to act as the central business logic layer. It manages the in-memory collections of users, equipment, and rentals, ensuring the `Program.cs` file remains clean and is only used for demonstration purposes.
