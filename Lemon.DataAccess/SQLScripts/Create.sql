CREATE DATABASE LemonDB
GO

USE LemonDB
GO

create table Accounts(
	Id int identity(1,1),
	CreatedTime datetime NOT NULL,
	
	UserName nvarchar(128) NOT NULL,
	Email nvarchar(128) NOT NULL,
	PasswordHash nvarchar(256) NOT NULL,
	Salt nvarchar(256) NOT NULL,
	CONSTRAINT PK_Accounts PRIMARY KEY (Id)
)
GO

create table Orders(
	Id int identity(1,1),
	CreatedTime datetime NOT NULL,
	
	CreaterId int NOT NULL,
	Title nvarchar (128),
	Content nvarchar(4000),
	ProbableCost decimal(10, 3),
	[Status] int NOT NULL,
	EmployeeId int NULL,
	
	CONSTRAINT PK_Orders PRIMARY KEY (Id),
	CONSTRAINT FK_Orders_Account FOREIGN KEY (CreaterId) REFERENCES Accounts(Id),
	CONSTRAINT FK_Orders_Account_Employee FOREIGN KEY (EmployeeId) REFERENCES Accounts(Id)
)
GO

create table OrderComments(
	Id int Identity(1,1),
	CreatedTime datetime NOT NULL,
	
	AuthorId int NOT NULL,
	Comment nvarchar(1024) NOT NULL,
	ProposedCost decimal(10,3) NOT NULL,
	OrderId int NOT NULL,
	
	CONSTRAINT PK_OrderComments PRIMARY KEY (Id),
	CONSTRAINT FK_OrderComments_Account FOREIGN KEY (AuthorId) REFERENCES Accounts(Id),
	CONSTRAINT FK_OrderComments_Orders FOREIGN KEY (OrderId) REFERENCES Orders(Id)
)
GO

create table [Messages](
	Id int Identity(1,1),
	CreatedTime datetime NOT NULL,
	
	[Text] nvarchar(2048) NOT NULL,
	SenderId int NOT NULL,
	ReceiverId int NOT NULL,
	
	CONSTRAINT PK_Messages PRIMARY KEY (Id),
	CONSTRAINT FK_Messages_Account_Sender FOREIGN KEY (SenderId) REFERENCES Accounts(Id),
	CONSTRAINT FK_Messages_Account_Reciver FOREIGN KEY (ReceiverId) REFERENCES Accounts(Id)
)
GO

create table UserRatings(
	Id int Identity(1,1),
	CreatedTime datetime NOT NULL,
	
	[Text] nvarchar(2048) NOT NULL,
	RatingSenderId int NOT NULL,
	RatingReceiverId int NOT NULL,
	Rating bit NOT NULL,
	Comment nvarchar(2048) NOT NULL,
	
	CONSTRAINT PK_UserRatings PRIMARY KEY (Id),
	CONSTRAINT FK_UserRatings_Account_Sender FOREIGN KEY (RatingSenderId) REFERENCES Accounts(Id),
	CONSTRAINT FK_UserRatings_Account_Reciver FOREIGN KEY (RatingReceiverId) REFERENCES Accounts(Id)
)
GO

create table UserEvents(
	Id int Identity(1,1),
	CreatedTime datetime NOT NULL,
	
	[Description] nvarchar(2048) NOT NULL,
	EventSunscriberId int NOT NULL,
	EventPublisherId int NOT NULL,
	EventType int NOT NULL,
	OrderId int NULL,
	CommentId int NULL,
	
	CONSTRAINT PK_UserEvents PRIMARY KEY (Id),
	CONSTRAINT FK_UserEvents_Account_Sender FOREIGN KEY (EventSunscriberId) REFERENCES Accounts(Id),
	CONSTRAINT FK_UserEvents_Account_Reciver FOREIGN KEY (EventPublisherId) REFERENCES Accounts(Id),
    CONSTRAINT FK_UserEvents_Order FOREIGN KEY (OrderId) REFERENCES Orders(Id),
	CONSTRAINT FK_UserEvents_OrderComment FOREIGN KEY (CommentId) REFERENCES OrderComments(Id)
)
GO