create table Medicine(id int primary key identity (0,1), description varchar(64) not null, long_description varchar(1024), quantity int not null);
create table Kits(id int primary key identity (0,1), description varchar(64) not null, long_description varchar(1024), quantity int not null);

create table Beds(id int primary key identity(0,1), description varchar(32), isUsed bit not null);

insert into Beds values ('Bed 1', 0), ('Bed 2', 0), ('Bed 3', 0);