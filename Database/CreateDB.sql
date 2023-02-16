CREATE DATABASE ShopDB
COLLATE Cyrillic_General_100_CI_AI
GO

USE ShopDB

CREATE TABLE Users (
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Users PRIMARY KEY,
  [Login] nvarchar(50) NOT NULL,
  ChatID int NOT NULL,
  Name nvarchar(100) NOT NULL,
  Birthday date NOT NULL
);

CREATE TABLE OneTimePasswords (
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_OneTimePasswords PRIMARY KEY,
  [Password] nvarchar(12) NOT NULL,
  UserID int NOT NULL,
  AttemptsCount int NOT NULL,
  CONSTRAINT FK_OneTimePasswords_UserID
    FOREIGN KEY (UserID)
      REFERENCES Users(ID) 
);
CREATE TABLE Categories (
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Categories PRIMARY KEY,
  Name nvarchar(50) NOT NULL,
);

CREATE TABLE Books (
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Goods PRIMARY KEY,
  Name nvarchar(100) NOT NULL,
  Author nvarchar(100) NOT NULL,
  Amount int NOT NULL,
  ReleaseDate date NOT NULL,
  PagesNumber int NOT NULL,
  AgeRestriction int NOT NULL,
  [Description] nvarchar(1000) NOT NULL,
  Picture nvarchar(1000) NOT NULL,
  Price decimal NOT NULL,
  CategoryID int NOT NULL,
  CONSTRAINT FK_Books_CategoryID
    FOREIGN KEY (CategoryID)
      REFERENCES Categories(ID)
);

CREATE TABLE Clients (
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Clients PRIMARY KEY,
  Name nvarchar(50) NOT NULL,
  Email nvarchar(50) NOT NULL,
  Age int NOT NULL
);

CREATE TABLE DeliveryPoints (
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_DeliveryPoints PRIMARY KEY,
  DeliveryAddress nvarchar(150) NOT NULL
);

CREATE TABLE Orders (
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Orders PRIMARY KEY,
  ClientID int NOT NULL,
  OrderDate datetime NOT NULL,
  OrderStatus nvarchar(100) NOT NULL,
  TotalCost decimal NOT NULL,
  DeliveryPointID int NOT NULL,
  CONSTRAINT FK_Orders_ClientID
    FOREIGN KEY (ClientID)
      REFERENCES Clients(ID),
  CONSTRAINT FK_DeliveryPoints_DeliveryPointID 
    FOREIGN KEY (DeliveryPointID)
      REFERENCES DeliveryPoints(ID)
);

CREATE TABLE OrderBook (
  OrderID int NOT NULL,
  BookID int NOT NULL
  CONSTRAINT FK_OrderBook_OrderID
    FOREIGN KEY (OrderID)
      REFERENCES Orders(ID),
  CONSTRAINT FK_OrderBook_BookID 
    FOREIGN KEY (BookID)
      REFERENCES Books(ID)
);


CREATE TABLE Basket (
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Basket PRIMARY KEY,
  ClientID int NOT NULL,
  BasketCreationDate datetime NOT NULL,
  TotalCost decimal NOT NULL,
  CONSTRAINT FK_Basket_ClientID
    FOREIGN KEY (ClientID)
      REFERENCES Clients(ID),
);

CREATE TABLE BasketBook (
  BasketID int NOT NULL,
  BookID int NOT NULL
  CONSTRAINT FK_BasketBook_BasketID
    FOREIGN KEY (BasketID)
      REFERENCES Basket(ID),
  CONSTRAINT FK_BasketBook_BookID 
    FOREIGN KEY (BookID)
      REFERENCES Books(ID)
);

