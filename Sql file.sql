IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'LoanManagementSystem')
CREATE DATABASE LoanManagementSystem;

USE LoanManagementSystem;


-- Create Customer table
CREATE TABLE Customer (
    CustomerId INT PRIMARY KEY,
    Name VARCHAR(255),
    EmailAddress VARCHAR(255),
    PhoneNumber VARCHAR(20),
    Address VARCHAR(255),
    CreditScore INT
);

-- Create Loan table
CREATE TABLE Loan (
    LoanId INT PRIMARY KEY,
    CustomerId INT FOREIGN KEY REFERENCES Customer(CustomerId),
    PrincipalAmount DECIMAL(18, 2),
    InterestRate DECIMAL(5, 2),
    LoanTerm INT,
    LoanType VARCHAR(50),
    LoanStatus VARCHAR(50)
);

alter table Loan alter column LoanId int identity (1,1);

-- Create HomeLoan table (inherits from Loan)
CREATE TABLE HomeLoan (
    LoanId INT PRIMARY KEY,
    PropertyAddress VARCHAR(255),
    PropertyValue INT,
    FOREIGN KEY (LoanId) REFERENCES Loan(LoanId)
);

-- Create CarLoan table (inherits from Loan)
CREATE TABLE CarLoan (
    LoanId INT PRIMARY KEY,
    CarModel VARCHAR(255),
    CarValue INT,
    FOREIGN KEY (LoanId) REFERENCES Loan(LoanId)
);

-- Insert sample values into Customer table
INSERT INTO Customer (CustomerId, Name, EmailAddress, PhoneNumber, Address, CreditScore)
VALUES
    (1, 'Aarav Sharma', 'aarav.sharma@example.com', '9876543210', '123 Main St', 520),
    (2, 'Advait Patel', 'advait.patel@example.com', '8765432109', '456 Oak St', 680),
    (3, 'Aradhya Singh', 'aradhya.singh@example.com', '7654321098', '789 Pine St', 500),
    (4, 'Ishaan Kumar', 'ishaan.kumar@example.com', '6543210987', '987 Cedar St', 450),
    (5, 'Saanvi Gupta', 'saanvi.gupta@example.com', '5432109876', '234 Elm St', 750),
    (6, 'Vihaan Verma', 'vihaan.verma@example.com', '4321098765', '567 Maple St', 680),
    (7, 'Anaya Reddy', 'anaya.reddy@example.com', '3210987654', '890 Birch St', 600),
    (8, 'Reyansh Kumar', 'reyansh.kumar@example.com', '2109876543', '123 Pine St', 720),
    (9, 'Aadya Mishra', 'aadya.mishra@example.com', '1098765432', '456 Oak St', 700),
    (10, 'Advika Singh', 'advika.singh@example.com', '9876543210', '789 Cedar St', 680);

-- Insert sample values into Loan table
INSERT INTO Loan (LoanId, CustomerId, PrincipalAmount, InterestRate, LoanTerm, LoanType, LoanStatus)
VALUES
    (101, 1, 100000, 5, 12, 'HomeLoan', 'Pending'),
    (102, 2, 50000, 3, 6, 'CarLoan', 'Pending'),
    (103, 3, 150000, 4, 24, 'HomeLoan', 'Pending'),
    (104, 4, 75000, 6, 12, 'CarLoan', 'Pending'),
    (105, 5, 200000, 5.5, 36, 'HomeLoan', 'Pending'),
    (106, 6, 100000, 4, 18, 'CarLoan', 'Pending'),
    (107, 7, 120000, 5, 24, 'HomeLoan', 'Pending'),
    (108, 8, 60000, 3.5, 9, 'CarLoan', 'Pending'),
    (109, 9, 180000, 6, 30, 'HomeLoan', 'Pending'),
    (110, 10, 90000, 4.5, 15, 'CarLoan', 'Pending');

-- Insert sample values into HomeLoan table
INSERT INTO HomeLoan (LoanId, PropertyAddress, PropertyValue)
VALUES
    (101, '456 Oak St', 200000),
    (103, '789 Pine St', 300000),
    (105, '234 Elm St', 400000),
    (107, '890 Birch St', 250000),
    (109, '789 Cedar St', 350000);

-- Insert sample values into CarLoan table
INSERT INTO CarLoan (LoanId, CarModel, CarValue)
VALUES
    (102, 'Toyota Camry', 25000),
    (104, 'Honda Civic', 20000),
    (106, 'Ford Mustang', 35000),
    (108, 'Chevrolet Cruze', 18000),
    (110, 'Hyundai Elantra', 22000);

	update Loan set PrincipalAmount= 1902545 where LoanId=102;

	SELECT * FROM Loan;
	select * from CarLoan
	SELECT * FROM Customer;