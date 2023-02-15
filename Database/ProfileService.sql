USE ProfileService

GO

INSERT INTO [Relationships] (RelationshipID,RelationshipName)
VALUES ('84251a89-a458-46f8-ba28-83df593ed2a9',N'Ông Bà');
INSERT INTO [Relationships] (RelationshipID,RelationshipName)
VALUES ('7cb6ef5f-648a-477a-9172-5172ff4f7868',N'Cha Mẹ');
INSERT INTO [Relationships] (RelationshipID,RelationshipName)
VALUES ('c956e62b-5709-4a4a-85b0-6a3452b48abf',N'Anh Chị');
INSERT INTO [Relationships] (RelationshipID,RelationshipName)
VALUES ('6a213e3d-6121-490e-87fc-747ba820491e',N'Vợ Chồng');
INSERT INTO [Relationships] (RelationshipID,RelationshipName)
VALUES ('99b8a1ab-1302-4443-9ef7-95fae52b4938',N'Em');
INSERT INTO [Relationships] (RelationshipID,RelationshipName)
VALUES ('ebfd7919-7210-4c54-bb76-fa37dcc191a3',N'Con cái');

GO

INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('4a015601-0c67-44c8-b15c-09795b44686e','75364b86-380c-42fc-a0ff-56eac258d824',N'Admin',N'Admin',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',0,'01/01/2001','0123456789','admin@gmail.com',N'Viet Nam');

INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('f1e1af4d-1349-4eeb-8038-32ee053905a6','5b4f6db5-3eb0-4eb2-886b-07bfee043579',N'Khang',N'Admin',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2001','0707123456','adminkhang@gmail.com',N'Ca Mau');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('cb643bd1-9674-402f-b449-1ac6282e1669','7d36545e-d590-47a5-be2c-04843182d4b8',N'Quynh',N'Admin',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2001','0369875412','adminquynh@gmail.com',N'Kien Giang');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('beaba080-353b-4e4a-9966-2dad1032a749','857fce86-2f07-43e1-a808-1197dd107acc',N'Thang',N'Admin',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2000','0369260600','adminthang@gmail.com',N'Can Tho');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('dcb023a8-fd35-439b-8011-3d20e6a420e7','9fbc9031-5f8f-4dd9-ac48-1a10ac2bbfb5',N'Canh',N'Admin',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2001','0785496321','admincanh@gmail.com',N'Bac Lieu');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('536f3d8c-adad-49b6-b799-3f5552a8aed1','03eca33c-12fe-49d3-9ad9-3d582a9bc95a',N'Sang',N'Admin',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2001','0903548874','adminsang@gmail.com',N'Can Tho');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('2b2cfaab-0e88-462c-b2be-4af928157c4d','8edf474e-0fcb-49fc-9c9e-4e902c7472f2',N'Khang',N'Doctor',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2001','0795323245','doctorkhang@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('9d7601de-a1b3-474a-92d2-6eeac50ad010','b514b384-ed9c-4d68-90ae-4f437bdee6b9',N'Quynh',N'Doctor',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2001','0123456785','doctorquynh@gmail.com',N'Ca Mau');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('475699ab-1582-429a-a675-7596c2b93c80','f8f4c1f6-b620-42e6-9da9-54438bbd13c5',N'Thang',N'Doctor',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2000','0123456784','doctorthang@gmail.com',N'Kien Giang');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('596cd928-d30c-43b2-8313-78f5a72e42eb','5145193c-51dc-4fed-8aa9-8adc068b9c69',N'Canh',N'Doctor',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2001','0123456783','doctorcanh@gmail.com',N'Can Tho');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('c26f5787-adb4-4f79-978e-9e1a55a48b8a','5a504858-ec5d-4a7b-9c07-9302e6964bd9',N'Sang',N'Doctor',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2001','0123459857','doctorsang@gmail.com',N'Bac Lieu');

INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('2692cf87-ade0-419a-85b3-a1c2a3c44968','b7bd24ed-941a-467a-81cb-b12b9bb1aed3',N'Khang',N'Supporter',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2001','0123457410','supporterkhang@gmail.com',N'Can Tho');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('afe0f9a1-05ff-42cb-bc27-b2f352b8b684','30c20bc2-e8e3-4052-815c-b1a50668e91c',N'Quynh',N'Supporter',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2001','0123459630','supporterquynh@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('f41241e2-71a8-4ffc-b306-bc2f20d7ab53','68b9aff7-97f9-46d1-8c9e-b6a497795713',N'Thang',N'Supporter',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2000','0123445630','supporterthang@gmail.com',N'Ca Mau');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('c8a431b9-c2c2-47cf-a169-c219d3b7607a','8701c16a-714b-4317-a8e3-c22842b051c0',N'Canh',N'Supporter',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2001','0127531630','supportercanh@gmail.com',N'Kien Giang');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('73070972-e93b-4dd2-9d6d-c7022759052e','c90d2651-857b-4694-bfa7-c3dd8a45031b',N'Sang',N'Supporter',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2001','0123951230','supportersang@gmail.com',N'Can Tho');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('45a9d235-0845-42e8-854b-ca62ac06ba0e','42ce372a-7078-4a4c-93a3-c5000d58bff1',N'Khang',N'User',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2001','0123357830','userkhang@gmail.com',N'Bac Lieu');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('bbb518fe-c93d-4845-ab2b-db4bb8aa964f','c36a9563-e078-4826-a2eb-ce8d9e70eb64',N'Quynh',N'User',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2001','0123454530','userquynh@gmail.com',N'Can Tho');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('77942dd9-ad18-49f2-8d4a-f0d7ecd616fd','f5dfd1eb-e828-4903-aaa9-ddd60642ef0e',N'Thang',N'User',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2000','0123951530','userthang@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('245cd364-da20-4cc9-b97c-f659a4c73f8a','bd64eb6b-1993-4ad7-ad81-f70eab00d869',N'Canh',N'User',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2001','0123753230','usercanh@gmail.com',N'Ca Mau');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('9b5a9fab-8f64-449e-bd5d-ff9bba314431','25fec2c5-87c1-4ec4-9014-9515e5d8863b',N'Sang',N'User',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2001','0123754130','usersang@gmail.com',N'Kien Giang');

INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('35c78e79-f9ff-4d18-87a1-70a206e6fddb','42ce372a-7078-4a4c-93a3-c5000d58bff1',N'Customer1',N'User',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2001','0123459512','customer1@gmail.com',N'Can Tho');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('e09510d0-98a0-47f9-a332-73cb75742b0b','42ce372a-7078-4a4c-93a3-c5000d58bff1',N'Customer2',N'User',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',0,'01/01/2001','0123457531','customer2@gmail.com',N'Bac Lieu');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('874e674c-7cc1-4551-8a58-75f2378f9aa7','c36a9563-e078-4826-a2eb-ce8d9e70eb64',N'Customer3',N'User',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',0,'01/01/2001','0123475341','customer3@gmail.com',N'Can Tho');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('293d15fa-12e0-4408-b194-8312375bcaaa','c36a9563-e078-4826-a2eb-ce8d9e70eb64',N'Customer4',N'User',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',0,'01/01/2001','0123475469','customer4@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('e07f41eb-00b0-4dc3-8c08-98c02956d4e7','bd64eb6b-1993-4ad7-ad81-f70eab00d869',N'Customer5',N'User',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2001','0127536941','customer5@gmail.com',N'Ca Mau');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('d67add11-294e-464d-8809-a9ae3194109a','bd64eb6b-1993-4ad7-ad81-f70eab00d869',N'Customer6',N'User',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',0,'01/01/2001','0127412531','customer6@gmail.com',N'Kien Giang');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('2ad38fef-416b-401d-8885-b719cdabc0fa','25fec2c5-87c1-4ec4-9014-9515e5d8863b',N'Customer7',N'User',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2001','0123458521','customer7@gmail.com',N'Can Tho');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('488de21c-8552-468e-b293-cbbfea3ba55b','25fec2c5-87c1-4ec4-9014-9515e5d8863b',N'Customer8',N'User',N'https://cdn.printgo.vn/uploads/media/772948/4-nguyen-tac-trong-thiet-ke-logo-nganh-y-duoc1_1585664899.jpg',1,'01/01/2001','0125127531','customer8@gmail.com',N'Bac Lieu');

GO

INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('2b2cfaab-0e88-462c-b2be-4af928157c4d',N'Bác sĩ',N'Bác sĩ ưu tú.','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);
INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('9d7601de-a1b3-474a-92d2-6eeac50ad010',N'Bác sĩ',N'Bác sĩ ưu tú.','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);
INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('475699ab-1582-429a-a675-7596c2b93c80',N'Bác sĩ',N'Bác sĩ ưu tú.','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);
INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('596cd928-d30c-43b2-8313-78f5a72e42eb',N'Bác sĩ',N'Bác sĩ ưu tú.','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);
INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('c26f5787-adb4-4f79-978e-9e1a55a48b8a',N'Bác sĩ',N'Bác sĩ ưu tú.','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);

GO

INSERT INTO [SupporterProfiles] (ProfileID,WorkStart,Description)
VALUES ('2692cf87-ade0-419a-85b3-a1c2a3c44968','01/01/2001',N'Tư vấn viên ưu tú.');
INSERT INTO [SupporterProfiles] (ProfileID,WorkStart,Description)
VALUES ('afe0f9a1-05ff-42cb-bc27-b2f352b8b684','01/01/2001',N'Tư vấn viên ưu tú.');
INSERT INTO [SupporterProfiles] (ProfileID,WorkStart,Description)
VALUES ('f41241e2-71a8-4ffc-b306-bc2f20d7ab53','01/01/2001',N'Tư vấn viên ưu tú.');
INSERT INTO [SupporterProfiles] (ProfileID,WorkStart,Description)
VALUES ('c8a431b9-c2c2-47cf-a169-c219d3b7607a','01/01/2001',N'Tư vấn viên ưu tú.');
INSERT INTO [SupporterProfiles] (ProfileID,WorkStart,Description)
VALUES ('73070972-e93b-4dd2-9d6d-c7022759052e','01/01/2001',N'Tư vấn viên ưu tú.');

GO

INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('45a9d235-0845-42e8-854b-ca62ac06ba0e','A',170,75,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('bbb518fe-c93d-4845-ab2b-db4bb8aa964f','A',175,65,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('77942dd9-ad18-49f2-8d4a-f0d7ecd616fd','B',170,75,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('245cd364-da20-4cc9-b97c-f659a4c73f8a','B',168,55,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('9b5a9fab-8f64-449e-bd5d-ff9bba314431','AB',170,60,'13accb41-1cad-4171-85aa-f3d76464c3dc');

INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('35c78e79-f9ff-4d18-87a1-70a206e6fddb','AB',170,75,'84251a89-a458-46f8-ba28-83df593ed2a9');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('e09510d0-98a0-47f9-a332-73cb75742b0b','O',175,65,'6a213e3d-6121-490e-87fc-747ba820491e');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('874e674c-7cc1-4551-8a58-75f2378f9aa7','O',170,75,'7cb6ef5f-648a-477a-9172-5172ff4f7868');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('293d15fa-12e0-4408-b194-8312375bcaaa','A',168,55,'ebfd7919-7210-4c54-bb76-fa37dcc191a3');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('e07f41eb-00b0-4dc3-8c08-98c02956d4e7','A',170,60,'c956e62b-5709-4a4a-85b0-6a3452b48abf');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('d67add11-294e-464d-8809-a9ae3194109a','B',170,75,'6a213e3d-6121-490e-87fc-747ba820491e');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('2ad38fef-416b-401d-8885-b719cdabc0fa','B',175,65,'c956e62b-5709-4a4a-85b0-6a3452b48abf');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('488de21c-8552-468e-b293-cbbfea3ba55b','AB',170,75,'99b8a1ab-1302-4443-9ef7-95fae52b4938');

GO
