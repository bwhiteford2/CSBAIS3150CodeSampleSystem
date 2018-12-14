go
CREATE DATABASE ABCHardware
GO
USE ABCHardware

GO 
-- delete tables if they exist
IF OBJECT_ID('SaleItem', 'U') IS NOT NULL DROP TABLE SaleItem
IF OBJECT_ID('Item', 'U') IS NOT NULL DROP TABLE Item
IF OBJECT_ID('Sale', 'U') IS NOT NULL DROP TABLE Sale
IF OBJECT_ID('Customer', 'U') IS NOT NULL DROP TABLE Customer
-- Order of table creation 
-- CUSTOMER TO SALE TO ITEM TO SaleItem

CREATE TABLE Customer 
(	
	CustomerID 
		INT
		NOT NULL,
	CustomerName 
		NVARCHAR(50)
		NOT NULL,
	Address 
		NVARCHAR(30)
		NOT NULL,
	City 
		NVARCHAR(20)
		NOT NULL,
	PostalCode
		NCHAR(6)
		NOT NULL,
	Province
		NVARCHAR(25)
		NOT NULL,
	CONSTRAINT PK_Customer_CustomerID PRIMARY KEY (CustomerID),
	CONSTRAINT CK_Customer_CustomerID CHECK (CustomerID >= 1)
);

CREATE TABLE Sale 
(
	SaleNumber 
		INT 
		NOT NULL,
	SaleDate
		DATE
		NOT NULL,
	CustomerID
		INT
		NOT NULL,
	SalesPerson
		NVARCHAR(30)
		NOT NULL,
	GST 
		SMALLMONEY
		NOT NULL,
	SubTotal
		MONEY
		NOT NULL,
	Total
		MONEY 
		NOT NULL,

	CONSTRAINT PK_Sale_SaleNumber PRIMARY KEY (SaleNumber),
	CONSTRAINT CK_Sale_SaleNumber CHECK (SaleNumber >= 1),
	CONSTRAINT FK_Sale_CustomerID FOREIGN KEY (CustomerID)
		REFERENCES Customer(CustomerID), 
	CONSTRAINT CK_Sale_GST CHECK (GST >= 0.01),
	CONSTRAINT CK_Sale_SubTotal CHECK (SubTotal >= 0.01),
	CONSTRAINT CK_Sale_Total CHECK (Total >= 0.01)
);

CREATE TABLE Item
(
	ItemCode 
		NVARCHAR(7)
		NOT NULL,
	Description
		NVARCHAR(30)
		NOT NULL,
	UnitPrice
		SMALLMONEY
		NOT NULL,
	QuantityOnHand
		INT
		NOT NULL DEFAULT(0),
	Active 
		BIT
		NOT NULL DEFAULT(1)	
	CONSTRAINT PK_Item_ItemCode PRIMARY KEY(ItemCode),
	CONSTRAINT CK_Item_UnitPrice CHECK (UnitPrice >= .01)
		
);

CREATE TABLE SaleItem
(
	SaleNumber
		INT
		NOT NULL,
	ItemCode
		NVARCHAR(7)
		NOT NULL,
	Quantity 
		SMALLINT
		NOT NULL,
	ItemTotal
		SMALLMONEY
		NOT NULL,

	CONSTRAINT PK_SaleItem_SaleNumber_ItemCode PRIMARY KEY(SaleNumber, ItemCode),
	CONSTRAINT FK_SaleItem_SaleNumber FOREIGN KEY(SaleNumber)
		REFERENCES Sale(SaleNumber),
	CONSTRAINT FK_SaleItem_ItemCode FOREIGN KEY(ItemCode)
		REFERENCES Item(ItemCode),
	CONSTRAINT CK_SaleItem_Quantity CHECK (Quantity >= 1),
	CONSTRAINT CK_SaleItem_ItemTotal CHECK (ItemTotal > 0)
);


-- INSERT DATA IN ORDER OF
-- CUSTOMER > SALE > ITEM > SALEITEM

INSERT INTO Customer (CustomerID, CustomerName,Address,City,PostalCode ,Province)
	VALUES (1, 'John Smith','12345 67 Street','Edmonton','T6T6T6', 'Alberta');

INSERT INTO Sale(SaleNumber, SaleDate, CustomerID,SalesPerson,GST, SubTotal, Total)
	VALUES (123456789, '01/16/2004', 1, 'Jenny Brooks', 8.05, 115.00, 123.05);
INSERT INTO ITEM (ItemCode, Description, UnitPrice)
	VALUES('I12847', 'Vice Grip 1/2 Inch', 10.00);
INSERT INTO ITEM (ItemCode, Description, UnitPrice)
	VALUES('N22475', 'Claw Hammer', 15.00);
INSERT INTO ITEM (ItemCode, Description, UnitPrice)
	VALUES('P77455', 'Torque Wrench', 75.00);

INSERT INTO SaleItem(SaleNumber, ItemCode,Quantity,ItemTotal)
	VALUES (123456789, 'I12847', 1, 10.00);
INSERT INTO SaleItem(SaleNumber, ItemCode,Quantity,ItemTotal)
	VALUES (123456789, 'N22475', 2, 30.00);
INSERT INTO SaleItem(SaleNumber, ItemCode,Quantity,ItemTotal)
	VALUES (123456789, 'P77455', 1, 75.00);


INSERT INTO Customer (CustomerID, CustomerName,Address,City,PostalCode ,Province)
	VALUES (2, 'Joe Smith','123 Fake Street','Edmonton','T6T6T6', 'Alberta');


INSERT INTO Sale(SaleNumber, SaleDate, CustomerID,SalesPerson,GST, SubTotal, Total)
	VALUES (123456781, '01/16/2004', 2, 'Sam Brooks', 16.10, 230, 246.10);

INSERT INTO SaleItem(SaleNumber, ItemCode,Quantity,ItemTotal)
	VALUES (123456781, 'I12847', 2, 20.00);
INSERT INTO SaleItem(SaleNumber, ItemCode,Quantity,ItemTotal)
	VALUES (123456781, 'N22475', 4, 60.00);
INSERT INTO SaleItem(SaleNumber, ItemCode,Quantity,ItemTotal)
	VALUES (123456781, 'P77455', 2, 150.00);

SELECT Sale.SaleNumber, SaleDate, CustomerName, Address, City, Province, PostalCode, SaleItem.ItemCode, Description, UnitPrice, Quantity, ItemTotal, SubTotal, Total
	FROM Sale INNER JOIN Customer ON Sale.CustomerID = Customer.CustomerID
		INNER JOIN SaleItem on Sale.SaleNumber = SaleItem.SaleNumber 
		INNER JOIN Item on SaleItem.ItemCode = Item.ItemCode
WHERE Sale.SaleNumber = 123456789

GO
CREATE PROC uspGetSale
	@SaleNumber INT
	as
	DECLARE @Status INT
	SET @Status = 0
	IF @SaleNumber IS NULL 
	BEGIN 
		SET @Status = 1
		RAISERROR('ERROR - @SaleNumber parameter value is required', 16,1);
	END 
	ELSE 
	BEGIN 
		SELECT Sale.SaleNumber, SaleDate, CustomerName, Address, City, Province, PostalCode, SaleItem.ItemCode, Description, UnitPrice, Quantity, ItemTotal, SubTotal, Total
		FROM Sale INNER JOIN Customer ON Sale.CustomerID = Customer.CustomerID
		INNER JOIN SaleItem on Sale.SaleNumber = SaleItem.SaleNumber 
		INNER JOIN Item on SaleItem.ItemCode = Item.ItemCode
		WHERE Sale.SaleNumber = @SaleNumber

		IF @@ERROR <> 0 
		BEGIN 
			SET @Status = 1
			RAISERROR('ERROR - Executing uspGetSale',16,1)
		END
	END
	RETURN @STATUS
GO
CREATE PROC uspAddItem
	@ItemCode NVARCHAR(7),
	@Description NVARCHAR(30),
	@UnitPrice SMALLMONEY,
	@QuantityOnHand INT,
	@Active BIT
	as
	DECLARE @Status INT
	SET @Status = 0
	IF @ItemCode IS NULL or @Description IS NULL OR @UnitPrice IS NULL
	BEGIN 
		--SET @Status = 1
		RAISERROR('ERROR - Item code, description, unit price are required', 16,1);
	END 
	ELSE 
	BEGIN 
		INSERT INTO ITEM (ItemCode, Description, UnitPrice, QuantityOnHand, Active)
		VALUES(@ItemCode, @Description,@UnitPrice,ISNULL(@QuantityOnHand,0),ISNULL(@Active,1));
		
		IF @@ERROR = 0 
		BEGIN 
			SET @Status = 1
			--RAISERROR('ERROR - Executing uspAddItem',16,1)
		END
	END
	RETURN @Status
GO
CREATE PROC uspUpdateItem
	@ItemCode NVARCHAR(7),
	@Description NVARCHAR(30),
	@UnitPrice SMALLMONEY,
	@QuantityOnHand INT,
	@Active BIT
	as
	DECLARE @Status INT
	SET @Status = 0
	IF @ItemCode IS NULL or @Description IS NULL OR @UnitPrice IS NULL
	BEGIN 
		--SET @Status = 1
		RAISERROR('ERROR - Item code, description, unit price are required', 16,1);
	END 
	ELSE 
	BEGIN 
		UPDATE ITEM 
		SET Description = @Description, 
			UnitPrice = @UnitPrice,
			QuantityOnHand = @QuantityOnHand,
			Active = @Active
		WHERE ItemCode = @ItemCode
		IF @@ERROR = 0 
		BEGIN 
			SET @Status = 1
			--RAISERROR('ERROR - Executing uspUpdateItem',16,1)
		END
	END
	RETURN @STATUS
GO
CREATE PROC uspAddCustomer
	@CustomerID INT,
	@CustomerName NVARCHAR(50),
	@Address NVARCHAR(30),
	@City NVARCHAR(20),
	@PostalCode NCHAR(6),
	@Province NVARCHAR(25)
	as
	DECLARE @Status INT
	SET @Status = 0
	IF @CustomerID IS NULL or @CustomerName IS NULL OR @Address IS NULL OR @City IS NULL OR @PostalCode IS NULL OR @Province IS NULL
	BEGIN 
		--SET @Status = 1
		RAISERROR('ERROR - CustomerID, CustomerName, Address, City, PostalCode and Province are required', 16,1);
	END 
	ELSE 
	BEGIN 
		INSERT INTO Customer (CustomerID, CustomerName, Address, City, PostalCode, Province)
		VALUES(@CustomerID, @CustomerName, @Address, @City, @PostalCode, @Province);
		
		IF @@ERROR <> 0 
		BEGIN 
			SET @Status = 1
			--RAISERROR('ERROR - Executing uspAddCustomer',16,1)
		END
	END
	RETURN @STATUS
GO
CREATE PROC uspDeleteCustomer
	@CustomerID INT	
	as
	DECLARE @Status INT
	SET @Status = 0
	IF @CustomerID IS NULL
	BEGIN 
		--SET @Status = 1
		RAISERROR('ERROR - CustomerID is required', 16,1);
	END 
	ELSE 
	BEGIN 
		DELETE FROM Customer where CustomerID = @CustomerID
		
		IF @@ERROR <> 0 
		BEGIN 
			SET @Status = 1
			--RAISERROR('ERROR - Executing uspDelete',16,1)
		END
	END
	RETURN @STATUS
GO
CREATE PROC uspUpdateCustomer
	@CustomerID INT,
	@CustomerName NVARCHAR(50),
	@Address NVARCHAR(30),
	@City NVARCHAR(20),
	@PostalCode NCHAR(6),
	@Province NVARCHAR(25)
	as
	DECLARE @Status INT
	SET @Status = 0
	IF @CustomerID IS NULL or @CustomerName IS NULL OR @Address IS NULL OR @City IS NULL OR @PostalCode IS NULL OR @Province IS NULL
	BEGIN 
		--SET @Status = 1
		RAISERROR('ERROR - CustomerID, CustomerName, Address, City, PostalCode and Province are required', 16,1);
	END 
	ELSE 
	BEGIN 
		UPDATE Customer 
		SET CustomerName = @CustomerName,
			Address =  @Address,
			City = @City,
			PostalCode =  @PostalCode,
			Province =  @Province
		WHERE CustomerID = @CustomerID
		IF @@ERROR = 0 
		BEGIN 
			SET @Status = 1
			--RAISERROR('ERROR - Executing uspAddCustomer',16,1)
		END
	END
	RETURN @STATUS
GO
CREATE PROC uspDeleteItem
	@ItemCode NVARCHAR(7)	
	as
	DECLARE @Status INT
	SET @Status = 0
	IF @ItemCode IS NULL 
	BEGIN 
		SET @Status = 1
		RAISERROR('ERROR - Item code is required', 16,1);
	END 
	ELSE 
	BEGIN 
		UPDATE ITEM 
		SET Active = 0
		WHERE ItemCode = @ItemCode
		IF @@ERROR = 0 
		BEGIN 
			SET @Status = 1
			--RAISERROR('ERROR - Executing uspDeleteItem',16,1)
		END
	END
	RETURN @STATUS
GO

CREATE PROC uspLookupItem
	@ItemCode NVARCHAR(7)	
	as
	DECLARE @Status INT
	SET @Status = 0
	IF @ItemCode IS NULL 
	BEGIN 		
		RAISERROR('ERROR - Item code is required', 16,1);
	END 
	ELSE 
	BEGIN 
		SELECT Description, UnitPrice, QuantityOnHand, Active
		FROM Item
		WHERE ItemCode = @ItemCode
		IF @@ERROR = 0 
		BEGIN 
			SET @Status = 1
			--RAISERROR('ERROR - Executing uspLookupItem',16,1)
		END
	END
	RETURN @Status
GO
CREATE PROC uspLookupCustomer
	@CustomerID INT	
	as
	DECLARE @Status INT
	SET @Status = 0
	IF @CustomerID IS NULL 
	BEGIN 		
		RAISERROR('ERROR - CustomerID is required', 16,1);
	END 
	ELSE 
	BEGIN 
		SELECT CustomerName, Address, City, PostalCode, Province
		FROM Customer
		WHERE CustomerID = @CustomerID 

		IF @@ERROR = 0 
		BEGIN 
			SET @Status = 1
			--RAISERROR('ERROR - Executing uspLookupItem',16,1)
		END
	END
	RETURN @Status
GO
