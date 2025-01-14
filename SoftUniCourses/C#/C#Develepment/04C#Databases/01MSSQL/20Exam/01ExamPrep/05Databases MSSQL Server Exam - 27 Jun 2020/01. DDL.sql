

CREATE TABLE Clients
(
ClientId INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Phone VARCHAR(12) NOT NULL CHECK(LEN(Phone)=12)
)

CREATE TABLE Mechanics
(
MechanicId INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Address VARCHAR(255) NOT NULL,
)

CREATE TABLE Models
(
ModelId INT PRIMARY KEY IDENTITY,
Name VARCHAR(50) UNIQUE NOT NULL,
)

CREATE TABLE Jobs
(
JobId INT PRIMARY KEY IDENTITY,
ModelId INT FOREIGN KEY (ModelId) REFERENCES Models(ModelId) NOT NULL,
Status VARCHAR(11) CHECK(LEN(Status)<=11 AND Status IN('Pending','In Progress','Finished')) DEFAULT('Pending') NOT NULL,
ClientId INT FOREIGN KEY (ClientId) REFERENCES Clients(ClientId) NOT NULL,
MechanicId  INT FOREIGN KEY (MechanicId) REFERENCES Mechanics(MechanicId),
IssueDate DATE NOT NULL,
FinishDate DATE
) 

--providing 1 for TRUE and 0 for FALSE.

CREATE TABLE Orders
(
OrderId  INT PRIMARY KEY IDENTITY,
JobId INT FOREIGN KEY (JobId) REFERENCES Jobs(JobId) NOT NULL,
IssueDate DATE,
Delivered  BIT DEFAULT(0) CHECK(Delivered IN (1,0)) NOT NULL
)

CREATE TABLE Vendors
(
	VendorId  INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) UNIQUE NOT NULL,
)

CREATE TABLE Parts
(
	PartId   INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	Description  VARCHAR(255),
	Price DECIMAL(6,2) CHECK(Price>0) NOT NULL,
	VendorId INT FOREIGN KEY (VendorId) REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT CHECK(StockQty>=0) DEFAULT(0) NOT NULL
)

CREATE TABLE OrderParts
(
	OrderId INT FOREIGN KEY (OrderId) REFERENCES Orders(OrderId) NOT NULL,
	PartId  INT FOREIGN KEY (PartId) REFERENCES Parts(PartId) NOT NULL,
	Quantity INT CHECK(Quantity>0) DEFAULT(1) NOT NULL,
	CONSTRAINT PK_Order_Parts PRIMARY KEY  (OrderId,PartId)
)

CREATE TABLE PartsNeeded
(
	JobId INT FOREIGN KEY (JobId) REFERENCES Jobs(JobId) NOT NULL,
	PartId  INT FOREIGN KEY (PartId) REFERENCES Parts(PartId) NOT NULL,
	Quantity INT CHECK(Quantity>0) DEFAULT(1) NOT NULL,
	CONSTRAINT PK_Parts_Needed PRIMARY KEY  (JobId,PartId) 
)
