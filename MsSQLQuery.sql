create table Person(
Id uniqueidentifier primary key default newid(),
FirstName nvarchar(100) not null,
LastName nvarchar(100) not null,
Email nvarchar(200) not null,
Password nvarchar(512) not null,
Birthday DateTime not null,
Gender Bit not null,
IsCoach Bit not null,
CoachId uniqueidentifier foreign key references Person(Id) 
)

create table Person_SportLog(
Id uniqueidentifier primary key default newid(),
PersonId uniqueidentifier not null foreign key references Person(Id),
Date DateTime not null,
Weight float not null,
Height int not null
)

create table Diet(
Id uniqueidentifier primary key default newid(),
Date DateTime not null,
PersonId uniqueidentifier not null foreign key references Person(Id),
TotalCalories float not null
)

create table Training(
Id uniqueidentifier primary key default newid(),
Date DateTime not null,
PersonId uniqueidentifier not null foreign key references Person(Id),
TotalCalories float not null
)

Create table Post(
Id uniqueidentifier primary key default newid(),
Date DateTime not null,
CreatorId uniqueidentifier not null foreign key references Person(Id),
Foto nvarchar(200),
Title nvarchar(200),
Text nvarchar(max)
)

Create table Post_Like(
Id uniqueidentifier primary key default newid(),
PersonId uniqueidentifier not null foreign key references Person(Id),
PostId uniqueidentifier not null foreign key references Post(Id)
)