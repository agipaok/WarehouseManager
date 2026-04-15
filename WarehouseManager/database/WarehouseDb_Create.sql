CREATE DATABASE WarehouseDb;
GO

USE WarehouseDb;
GO

CREATE TABLE dbo.Products
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL,
    SKU NVARCHAR(MAX) NOT NULL,
    Category NVARCHAR(MAX) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Stock INT NOT NULL,
    MinStock INT NOT NULL
);
GO

CREATE TABLE dbo.Suppliers
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL,
    ContactPerson NVARCHAR(MAX) NOT NULL,
    Phone NVARCHAR(MAX) NOT NULL,
    Email NVARCHAR(MAX) NOT NULL
);
GO

CREATE TABLE dbo.StockMovements
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    MovementType NVARCHAR(MAX) NOT NULL,
    CreatedAt DATETIME2 NOT NULL,
    Notes NVARCHAR(MAX) NOT NULL,
    CONSTRAINT FK_StockMovements_Products
        FOREIGN KEY (ProductId) REFERENCES dbo.Products(Id)
            ON DELETE CASCADE
);
GO

CREATE INDEX IX_StockMovements_ProductId
    ON dbo.StockMovements(ProductId);
GO

CREATE TABLE dbo.NginxLogEntries
(
    Id BIGINT NOT NULL PRIMARY KEY,
    Epoch BIGINT NOT NULL,
    RemoteIpAddress NVARCHAR(45) NOT NULL,
    RemoteUser NVARCHAR(100) NOT NULL,
    [Timestamp] DATETIMEOFFSET NOT NULL,
    RequestPath NVARCHAR(500) NOT NULL,
    StatusCode INT NOT NULL,
    BytesSent BIGINT NOT NULL
);
GO