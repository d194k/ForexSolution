CREATE TABLE ExchangeRateSyncBase(
Id int Identity(1,1) primary key,
BaseCurrency char(3) not null,
SyncDate date not null,
Timestamp int not null,
IsDeleted bit default(0) not null,
CreatedBy int default(0) not null,
CreatedDate datetime default(getdate()) not null,
UpdatedBy int,
UpdatedDate datetime,
Constraint UK_SyncBase Unique(BaseCurrency, SyncDate)
); 


CREATE TABLE ExchangeRates(
Id int identity(1,1) primary key,
SyncId int not null,
Currency char(3) not null,
Rate float not null,
IsDeleted bit default(0) not null,
CreatedBy int default(0) not null,
CreatedDate datetime default(getdate()) not null,
UpdatedBy int,
UpdatedDate datetime,
CONSTRAINT UK_ExchangeRates Unique(SyncId,Currency,Rate),
CONSTRAINT FK_SyncBase FOREIGN KEY(SyncId) REFERENCES ExchangeRateSyncBase(Id)
);