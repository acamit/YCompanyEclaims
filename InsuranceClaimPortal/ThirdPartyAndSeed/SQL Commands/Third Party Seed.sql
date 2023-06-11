INSERT INTO Policies VALUES 
('Car Insurance', '202301', '03-04-2023', '03-04-2028', 'Credit Card', '30000', '1', 'Insurance for SUV', '01-04-2023'),
('Bike Insurance', '202302', '11-04-2023', '10-04-2028', 'Debit Card', '3000', '1', 'Insurance for Bike', '11-04-2023');

INSERT INTO Driver VALUES
('Amit','Chawla', '19930101', 'amitchawla@gmail.com', '9876754356', '20120201', 'Punjab', 'AC2012', 1, 'Self', '20230401', 1, 1),
('Tushar','Kumar', '19990112', 'tusharkumar@gmail.com', '8860542694', '20170214', 'Delhi', 'TK2017', 1, 'Self', '20230411', 1, 2);

INSERT INTO Vehicles VALUES
(2023, 'Tata Harrier', 'Black', 'PB8AS1993', 1, 1),
(2022, 'Suzuki Access', 'White', 'DL8AD2453', 1, 2);

select * from Policies;
select * from Driver;
select * from Vehicles;
