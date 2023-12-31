--Opened------Closed-------cust_id autoincrement------emp_id in reservation 24elo?-----edit my project to make it Opened Closed
create table customer(name varchar(20) ,
					  phone_number INT ,   
					  cust_id INT Identity(1,1)  ,
					  gender    varchar(10) ,
					  credit_card_ID INT ,
					  PRIMARY KEY(cust_id)
					  );


create table employee (
					emp_id INT identity(1,1)   ,
					password varchar(20),
					name varchar(20) ,
					   age INT ,   
					   salary   FLOAT ,
					   title      varchar(20) ,  --role
					   task     varchar (50),
					   phone_no varchar(14),
					   nationality varchar (50),
					   gender  varchar (6),
					   PRIMARY KEY(emp_id)
					  );

create table room (   
					  room_type varchar(20) ,
                      price_per_night  FLOAT ,  
					  room_number INT ,   
					  room_status  varchar(30) ,
					  PRIMARY KEY(room_number)
					  );

create table reservation (  
							  room_number INT ,
							  reservation_date DATE ,
					          reservation_number INT identity(1,1) , 
							  cust_id   INT ,
							  PRIMARY KEY(reservation_number)
					     );





create table rates ( reservation_number INT  ,
                     rate               INT  CHECK(rate>=0 and rate<=5) );  


create table offer(todayOffer varchar(max),
					offerID INT Identity(1,1));

ALTER TABLE rates
ADD CONSTRAINT  fk_k
foreign key (reservation_number)
references 
reservation(reservation_number);


ALTER TABLE reservation
ADD CONSTRAINT  fkkkk
foreign key (cust_id)
references 
customer(cust_id);


ALTER TABLE reservation
ADD CONSTRAINT  fkkkkk
foreign key (room_number)
references 
room(room_number);


-- Adding records to the 'customer' table
INSERT INTO customer (name, phone_number, gender, credit_card_ID)
VALUES
  ('John Doe', 1234567,  'Male', 123456756),
  ('Jane Doe', 9876543,  'Female', 17654321),
  ('Bob Smith', 5551234,  'Male', 987456),
  ('Alice Johnson', 999888, 'Female', 45678),
  ('Charlie Brown', 111333, 'Male', 789012);

-- Adding records to the 'employee' table
INSERT INTO employee ( name,password, age, salary, title, task)
VALUES
  ( 'gelo','pass', 25, 50000.00, 'Manager', 'Null'),
  ( 'loay','pass', 30, 60000.00, 'Admin', 'Null'),
  ( 'ahmed','pass', 28, 55000.00, 'HouseKeeper', 'Clean room 1'),
  ( 'hassan', 'pass',35, 70000.00, 'Receiption', 'null');
 

-- Adding records to the 'room' table
INSERT INTO room (room_type, price_per_night, room_number, room_status)
VALUES
  ('Single', 100.00, 101, 'Opened'),
  ('Double', 150.00, 102, 'Opened'),
  ('Single', 200.00, 103, 'Opened'),
  ('Double', 80.00, 104, 'Closed'),
  ('Single', 180.00, 105, 'Closed');

-- Adding records to the 'reservation' table
INSERT INTO reservation (room_number, reservation_date,  cust_id)
VALUES
 
  (104, '2023-04-05',  4),
  (105, '2023-05-12',  5);

-- Adding records to the 'entertainment' table


-- Adding records to the 'rates' table
INSERT INTO rates (reservation_number, rate)
VALUES
  (1, 4),
  (2, 5)



  