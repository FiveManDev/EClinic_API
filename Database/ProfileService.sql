USE ProfileService

GO

INSERT INTO [Relationships] (RelationshipID,RelationshipName)
VALUES ('84251a89-a458-46f8-ba28-83df593ed2a9',N'Grandfather');
INSERT INTO [Relationships] (RelationshipID,RelationshipName)
VALUES ('7cb6ef5f-648a-477a-9172-5172ff4f7868',N'Grandmother');
INSERT INTO [Relationships] (RelationshipID,RelationshipName)
VALUES ('c956e62b-5709-4a4a-85b0-6a3452b48abf',N'Mother');
INSERT INTO [Relationships] (RelationshipID,RelationshipName)
VALUES ('6a213e3d-6121-490e-87fc-747ba820491e',N'Father');
INSERT INTO [Relationships] (RelationshipID,RelationshipName)
VALUES ('ebfd7919-7210-4c54-bb76-fa37dcc191a3',N'Brother');
INSERT INTO [Relationships] (RelationshipID,RelationshipName)
VALUES ('8782bbd0-2f56-4fd4-89d6-081396549bfb',N'Sister');
INSERT INTO [Relationships] (RelationshipID,RelationshipName)
VALUES ('15f25288-4ff7-4bcf-b9ae-11fc91074863',N'Son');
INSERT INTO [Relationships] (RelationshipID,RelationshipName)
VALUES ('800101db-589a-48b7-9126-24ee55465a9d',N'Daughter');
INSERT INTO [Relationships] (RelationshipID,RelationshipName)
VALUES ('f8b486a9-6c27-4d34-be35-2f9a0cfa9999',N'Husband');
INSERT INTO [Relationships] (RelationshipID,RelationshipName)
VALUES ('fa428210-51c9-45ae-86d5-3320db152e6a',N'Wife');
INSERT INTO [Relationships] (RelationshipID,RelationshipName)
VALUES ('e1a1d664-31df-44e3-b78c-8cb948dc603b',N'Other');

GO

INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('4a015601-0c67-44c8-b15c-09795b44686e','75364b86-380c-42fc-a0ff-56eac258d824',N'Admin',N'Test',N'',0,'01/01/2001','0369456789','admintest@gmail.com',N'Viet Nam');

INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('f1e1af4d-1349-4eeb-8038-32ee053905a6','5b4f6db5-3eb0-4eb2-886b-07bfee043579',N'Khang',N'Admin',N'Image/Khang.png',1,'01/01/2001','0369123456','adminkhang@gmail.com',N'Ca Mau');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('cb643bd1-9674-402f-b449-1ac6282e1669','7d36545e-d590-47a5-be2c-04843182d4b8',N'Quynh',N'Admin',N'Image/Quynh.png',1,'01/01/2001','0369875412','adminquynh@gmail.com',N'Kien Giang');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('beaba080-353b-4e4a-9966-2dad1032a749','857fce86-2f07-43e1-a808-1197dd107acc',N'Thang',N'Admin',N'Image/Thang.png',1,'01/01/2000','0369260600','adminthang@gmail.com',N'Can Tho');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('dcb023a8-fd35-439b-8011-3d20e6a420e7','9fbc9031-5f8f-4dd9-ac48-1a10ac2bbfb5',N'Canh',N'Admin',N'Image/Canh.png',1,'01/01/2001','0369496321','admincanh@gmail.com',N'Bac Lieu');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('536f3d8c-adad-49b6-b799-3f5552a8aed1','03eca33c-12fe-49d3-9ad9-3d582a9bc95a',N'Sang',N'Admin',N'Image/Sang.png',1,'01/01/2001','0369548874','adminsang@gmail.com',N'Can Tho');

INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('003a894b-36a8-4471-b906-dc627a6ce9c2','99b8a1ab-1302-4443-9ef7-95fae52b4938',N'Khang',N'Expert',N'Image/Khang.png',1,'01/01/2001','0369546798','expertkhang@gmail.com',N'Ca Mau');

INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('1d3b82bb-e1c0-4100-a61b-1cba0bfa117a','22849f83-a5b4-49eb-93ed-e2d942254521',N'Doctor',N'Test',N'',1,'01/01/2001','0369123789','doctortest@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('2b2cfaab-0e88-462c-b2be-4af928157c4d','8edf474e-0fcb-49fc-9c9e-4e902c7472f2',N'Tuan',N'Le Anh',N'Image/doctor1.png',1,'01/01/1975','0369323245','leanhtuan@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('9d7601de-a1b3-474a-92d2-6eeac50ad010','b514b384-ed9c-4d68-90ae-4f437bdee6b9',N'Bich Dao',N'Nguyen Thi',N'Image/doctor2.jpg',1,'01/01/1975','0369456785','nguybichdaoenthi@gmail.com',N'Ca Mau');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('475699ab-1582-429a-a675-7596c2b93c80','f8f4c1f6-b620-42e6-9da9-54438bbd13c5',N'Nam',N'Tran Quang',N'Image/doctor3.png',1,'01/01/1975','0369456784','tranquangnam@gmail.com',N'Kien Giang');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('596cd928-d30c-43b2-8313-78f5a72e42eb','5145193c-51dc-4fed-8aa9-8adc068b9c69',N'Quy Quyen',N'Dao Bui',N'Image/doctor4.jpg',1,'01/01/1975','0369456783','daobuiquyquyen@gmail.com',N'Can Tho');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('c26f5787-adb4-4f79-978e-9e1a55a48b8a','5a504858-ec5d-4a7b-9c07-9302e6964bd9',N'Hang',N'Trinh Thi',N'Image/Doctor5.jpeg',1,'01/01/1990','0369459857','trinhthihang@gmail.com',N'Bac Lieu');

INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('5e321cdc-e695-4683-a86b-ede613f37569','b0ed6e7d-5824-49ee-a025-8de3b677a5fc',N'Van Khanh',N'Nguyen Hong',N'Image/doctor6.png',0,'01/01/1985','0369838783','vankhanh123@gmail.com',N'HCM');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('ed545e96-3617-455e-a022-f3e6ec1b7ae6','7fdd10b3-2070-47f5-9414-ab93ade7fd5e',N'Anh Tuyet',N'Che Thi',N'Image/doctor7.png',0,'01/01/1985','0369702825','anhtuyet123@gmail.com',N'Ca Mau');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('bc80e305-297b-4112-bc9b-f6125844b878','a156cf24-3cbb-43d7-a76b-d09c842deeda',N'Bach Tuyet',N'Phan Thi',N'Image/doctor8.png',0,'01/01/1985','0369238596','bachtuyet123@gmail.com',N'Kien Giang');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('907266cc-baf8-4704-a52c-008c9fb20f3c','162d22a0-8124-4e17-842e-f725c823aa23',N'Dung',N'Le Trung',N'Image/doctor9.png',1,'01/01/1985','0369215152','trungdung123@gmail.com',N'Can Tho');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('27f31308-4cc0-4917-912f-01fbe8934529','246a5605-cac0-4736-9446-10053bead807',N'Toan',N'Nguyen Duy',N'Image/doctor10.png',1,'01/01/1985','0369531364','duytoan123@gmail.com',N'Bac Lieu');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('75e8c74e-0847-4ed1-871c-03e537bef987','f9afc6da-14e9-4949-bff2-159d1a374bda',N'Truong',N'Pham minh',N'Image/doctor11.png',1,'01/01/1985','0369582841','minhtruong123@gmail.com',N'Ca Mau');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('1e7dc4c2-cee6-44c4-b24c-0a8f54e37d5d','8baefb8b-794e-4d67-ad9b-1e3c747c110a',N'Anh Tuyet',N'Tran Ngoc',N'Image/doctor12.png',0,'01/01/1985','0369401479','anhtuyet234@gmail.com',N'Kien Giang');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('e84cad00-8b27-4077-8f12-0dd69a43ff79','7cfcd120-4e00-4ebd-8ba8-239e9b67bc65',N'Bich Ngoc',N'Nguyen Thi',N'Image/doctor13.png',0,'01/01/1985','0369081606','bichngoc123@gmail.com',N'Can Tho');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('bb8717c3-4868-4b1c-9200-15e1f7c29779','c6dca19e-ca50-4521-863d-379cbd120013',N'Phuoc',N'Phan Ngoc',N'Image/doctor14.png',1,'01/01/1985','0369019765','ngocphuoc123@gmail.com',N'Bac Lieu');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('ed18c0f2-82bc-46f7-b675-16e71b7b6ee9','2268c972-4fb2-4a01-8dea-43341f1e6931',N'Thao',N'Nguyen Thi',N'Image/doctor15.png',0,'01/01/1985','0369339752','thithao234@gmail.com',N'HCM');

INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('5be2d966-3030-494c-8bec-2f7181bc4fc6','32ab71e0-a75d-4d39-8d5d-e66525477d48',N'Supporter',N'Test',N'',1,'01/01/2001','0369456889','supportertest@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('2692cf87-ade0-419a-85b3-a1c2a3c44968','b7bd24ed-941a-467a-81cb-b12b9bb1aed3',N'Trong',N'Bui Huu',N'Image/user1.png',1,'01/01/2001','0369457410','huutrong123@gmail.com',N'Can Tho');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('afe0f9a1-05ff-42cb-bc27-b2f352b8b684','30c20bc2-e8e3-4052-815c-b1a50668e91c',N'Nghia',N'Le Trong',N'Image/user2.png',1,'01/01/2001','0369459630','trongnghia123@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('f41241e2-71a8-4ffc-b306-bc2f20d7ab53','68b9aff7-97f9-46d1-8c9e-b6a497795713',N'Nhan',N'Nguyen Huu',N'Image/user3.png',1,'01/01/2000','0369445630','huunhan123@gmail.com',N'Ca Mau');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('c8a431b9-c2c2-47cf-a169-c219d3b7607a','8701c16a-714b-4317-a8e3-c22842b051c0',N'Khanh',N'Nguyen Van',N'Image/user4.png',1,'01/01/2001','0369531630','vankhanh234@gmail.com',N'Kien Giang');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('73070972-e93b-4dd2-9d6d-c7022759052e','c90d2651-857b-4694-bfa7-c3dd8a45031b',N'Tin',N'Le Trong',N'Image/user5.png',1,'01/01/2001','0369951230','trongtin123@gmail.com',N'Can Tho');

INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('e1d2bbb8-d3ac-4806-bc85-41a2630433e9','63da4fe0-de4d-4c8e-b8c8-ec3202c20038',N'User',N'Test',N'',1,'01/01/2001','0369156789','usertest@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('45a9d235-0845-42e8-854b-ca62ac06ba0e','42ce372a-7078-4a4c-93a3-c5000d58bff1',N'Bao',N'Nguyen Hoang',N'Image/user6.png',1,'01/01/2001','0369357830','hoangbao123@gmail.com',N'Bac Lieu');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('bbb518fe-c93d-4845-ab2b-db4bb8aa964f','c36a9563-e078-4826-a2eb-ce8d9e70eb64',N'Duc',N'Le Nhat',N'Image/user7.png',1,'01/01/2001','0369454530','nhatduc123@gmail.com',N'Can Tho');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('77942dd9-ad18-49f2-8d4a-f0d7ecd616fd','f5dfd1eb-e828-4903-aaa9-ddd60642ef0e',N'Trong',N'Le Huu',N'Image/user8.png',1,'01/01/2000','0369951530','huutrong456@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('245cd364-da20-4cc9-b97c-f659a4c73f8a','bd64eb6b-1993-4ad7-ad81-f70eab00d869',N'Huy',N'Dang Minh',N'Image/user9.png',1,'01/01/2001','0369753230','minhhuy123@gmail.com',N'Ca Mau');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('9b5a9fab-8f64-449e-bd5d-ff9bba314431','25fec2c5-87c1-4ec4-9014-9515e5d8863b',N'Trung',N'Le Quoc',N'Image/user10.png',1,'01/01/2001','0369754130','quoctrung123@gmail.com',N'Kien Giang');

INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('35c78e79-f9ff-4d18-87a1-70a206e6fddb','42ce372a-7078-4a4c-93a3-c5000d58bff1',N'Hung',N'Tran Kien',N'',1,'01/01/2001','0369459512','kienhung123@gmail.com',N'Can Tho');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('e09510d0-98a0-47f9-a332-73cb75742b0b','42ce372a-7078-4a4c-93a3-c5000d58bff1',N'Tu',N'Tran Diem',N'',0,'01/01/2001','0369457531','diemtu123@gmail.com',N'Bac Lieu');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('874e674c-7cc1-4551-8a58-75f2378f9aa7','c36a9563-e078-4826-a2eb-ce8d9e70eb64',N'Linh',N'Tang Du',N'',0,'01/01/2001','0369475341','tangdulinh123@gmail.com',N'Can Tho');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('293d15fa-12e0-4408-b194-8312375bcaaa','c36a9563-e078-4826-a2eb-ce8d9e70eb64',N'Vy',N'Nguyen Thao',N'',0,'01/01/2001','0369475469','thaovy123@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('e07f41eb-00b0-4dc3-8c08-98c02956d4e7','bd64eb6b-1993-4ad7-ad81-f70eab00d869',N'Tri',N'Bui Minh',N'',1,'01/01/2001','0369536941','minhtri123@gmail.com',N'Ca Mau');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('d67add11-294e-464d-8809-a9ae3194109a','bd64eb6b-1993-4ad7-ad81-f70eab00d869',N'My',N'Bui Khanh',N'',0,'01/01/2001','0369412531','khanhmy123@gmail.com',N'Kien Giang');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('2ad38fef-416b-401d-8885-b719cdabc0fa','25fec2c5-87c1-4ec4-9014-9515e5d8863b',N'Hung',N'Bui Minh',N'',1,'01/01/2001','0369458521','minhhung123@gmail.com',N'Can Tho');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('488de21c-8552-468e-b293-cbbfea3ba55b','25fec2c5-87c1-4ec4-9014-9515e5d8863b',N'Trong',N'Ly Hung',N'',1,'01/01/2001','0369127531','hungtrong123@gmail.com',N'Bac Lieu');

INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('6946f661-40d9-45e7-8527-5045522dd8c5','63da4fe0-de4d-4c8e-b8c8-ec3202c20038',N'Hieu',N'Do Trong',N'Image/user19.png',1,'01/01/1980','0369975330','tronghieu@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('9132f03d-c300-4725-b35a-7e364631eb7c','63da4fe0-de4d-4c8e-b8c8-ec3202c20038',N'Anh',N'Nhat Tinh',N'Image/user20.png',1,'01/01/1982','0369915930','tinhanh@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('d88c45d5-382a-4a86-977c-8092c14e83f9','63da4fe0-de4d-4c8e-b8c8-ec3202c20038',N'Ha',N'Le Dieu',N'',1,'01/01/1960','0369925830','ledieuha@gmail.com',N'Viet Nam');

INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('350af705-bd31-40ab-8b0f-3a064d4e3df9','abac9d62-375e-42e9-898d-648864d34985',N'My Anh',N'Le Thi',N'Image/user11.png',0,'01/01/2001','0369411131','myanh123@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('ac9c04ad-885e-4c73-b035-3e53b5e34284','ec3bdeb1-dfc1-442f-8b4b-68ee68cbc848',N'Hoai Yen',N'Le Vo',N'Image/user12.png',0,'01/01/2001','0369422231','hoaiyen123@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('295c36f4-54d7-4183-b6b1-450054047200','9248a7b5-d937-48db-abe6-8ffeb3bf0d0e',N'Yen Nhi',N'Nguyen Thi',N'Image/user13.png',0,'01/01/2001','0369433331','yennhi123@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('cd3e7605-81ac-4a97-9ca3-58ed958fb4b6','6cc6f27f-ac78-464e-a519-a56798e38ae9',N'Nhi',N'Dang Thi',N'Image/user14.png',0,'01/01/2001','0369444431','thinhi123@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('ca44f559-803f-4daf-b024-9c870c62318e','3480d242-8d09-43e8-910d-adbd9cb84012',N'Dat',N'Dao Phuoc',N'Image/user15.png',1,'01/01/2001','0369455531','phuocdat123@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('6ac68c37-0ae3-478f-9c22-9cf22fa3db1c','be694904-b294-4c51-a0c4-db8ce8537dea',N'Hung',N'Lu Tri',N'Image/user16.png',1,'01/01/2001','0369416661','trihung123@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('9ad897ac-89d2-4ef0-be64-a7d58dfd5f8d','bb974f0d-9383-4502-bb94-fc1d0fc3eab6',N'Dat',N'Nguyen Hoang',N'Image/user17.png',1,'01/01/2001','0369417771','hoangdat123@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('f2427dc3-481e-4e31-8f81-d06526bdaf58','420f4420-7e8b-4100-943a-fededd5c4cde',N'Sang',N'Nguyen Thanh',N'Image/user18.png',1,'01/01/2001','0369418881','thanhsang123@gmail.com',N'Viet Nam');

INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('1e7028e1-356c-429b-b5e1-1b6b130d5871','e304370f-3f72-44f1-af0e-6daaa9954ef8',N'An',N'Le Ngoc',N'Image/user21.png',0,'01/01/2001','0369107100','ngocan234@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('9a910220-9883-4b23-b0e2-1ecab6c46275','6057ce03-8923-47b0-b0cf-8bcb07f06b44',N'Tram Anh',N'Nguyen Ngoc',N'Image/user22.png',0,'01/01/2001','0369018361','tramanh234@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('81a9cc52-7b67-4a61-8bcc-3782be771fce','9b0a2802-cac5-488f-843d-91d3adb99fbf',N'Anh',N'Pham Viet',N'Image/user23.png',1,'01/01/2001','0369302398','vietanh234@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('57d380f2-9ce4-4d07-9100-37b0dc0e32af','50e7bae7-3a74-4232-ab4c-a30214f6c6b9',N'Quynh Anh ',N'Bui Thi',N'Image/user24.png',0,'01/01/2001','0369158117','quynhanh234@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('0231f164-2680-42f5-84fb-5f07428eaddd','9cce93e4-f88e-47fa-93ce-a6ec0569f76b',N'Anh',N'Vu Duc',N'Image/user25.png',1,'01/01/2001','0369784897','ducanh234@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('f3575ab5-1d36-426c-888c-6415324c3f0d','bdd1b27d-5fbf-4a35-a5f4-b8cd47de498c',N'Linh Chi',N'Nguyen Phung',N'Image/user26.png',0,'01/01/2001','0369923546','linhchi234@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('4b6f23f7-a4e2-47d8-a933-83d52ba8d9b7','fe9c4099-9b05-45dd-a299-c408ba574878',N'Dung',N'Duong My',N'Image/user27.png',0,'01/01/2001','0369661640','mydung234@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('bde3df23-94a5-4d12-8342-07307ceca903','826e96cd-e68e-4e21-b17f-d5adc5545872',N'Duy',N'Nguyen Manh',N'Image/user28.png',1,'01/01/2001','0369558739','manhduy234@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('a0bccb90-a68c-42c1-bf36-2a20f85a6fb0','5a49af6d-19cb-4b15-9456-e3a1a9a083f7',N'Duong',N'Nguyen Thuy',N'Image/user29.png',0,'01/01/2001','0369749613','thuyduong234@gmail.com',N'Viet Nam');
INSERT INTO [Profiles] (ProfileID,UserID,FirstName,LastName,Avatar,Gender,DateOfBirth,Phone,Email,Address)
VALUES ('2590134e-c741-405e-ba2a-2be38a27d8bc','ca064e23-1ce0-4ca8-b045-ea8cf23bbc8c',N'Hang',N'Luu Minh',N'Image/user30.png',0,'01/01/2001','0369596959','minhhang234@gmail.com',N'Viet Nam');


GO

INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('1d3b82bb-e1c0-4100-a61b-1cba0bfa117a',N'BS Test',N'Account bác sĩ dùng để test.','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);
INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('2b2cfaab-0e88-462c-b2be-4af928157c4d',N'ThS.BS',N'Thạc sĩ, Bác sĩ Lê Anh Tuấn tốt nghiệp Y khoa niên khóa 1989- 1995, hạng ưu, trường ĐHYD TPHCM - Thạc Sĩ Niệu khoa năm 2006 – Tu nghiệp Niệu khoa và Nam khoa – Vi phẫu tại Ấn Độ  và Thái Lan.','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);
INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('9d7601de-a1b3-474a-92d2-6eeac50ad010',N'PGS.TS.BS',N'PGS.TS.BS. Nguyễn Thị Bích Đào là chuyên gia đầu ngành trong lĩnh vực Nội tiết - Đái tháo đường tại Việt Nam với nhiều năm kinh nghiệm trong điều trị và giảng dạy.','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);
INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('475699ab-1582-429a-a675-7596c2b93c80',N'TS.BS',N'Tiến sĩ, Bác sĩ Trần Quang Nam hiện đang là Trưởng khoa Nội Tiết bệnh viện Đại học Y Dược TP. HCM, Phó Trưởng Bộ môn Nội tiết tại Đại học Y dược TP. HCM. Bác sĩ có nhiều năm kinh nghiệm trong việc chuyên khám và điều trị các bệnh như đái tháo đường, bệnh bướu cổ, bệnh nội tiết và các bệnh nội khoa.','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);
INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('596cd928-d30c-43b2-8313-78f5a72e42eb',N'TS.BS',N'Tiến sĩ, Bác sĩ Đào Bùi Quý Quyền hiện là Trưởng khoa Nội thận - Tiết niệu, có hơn 20 năm kinh nghiệm khám và điều trị bệnh tại Bệnh Viện Chợ Rẫy.','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);
INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('c26f5787-adb4-4f79-978e-9e1a55a48b8a',N'BS',N'Tốt nghiệp đại học loại Khá ở Khoa Y- Đại học quốc gia TP HCM. Học Sơ bộ Nội Tim mạch ở bệnh viện Chợ Rẫy. Làm Hồi sức tích cực 3 năm ở bệnh viện Thống Nhất. Hiện đang là bác sĩ khoa Nội tim mạch bệnh viện Xuyên Á.','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);

INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('5e321cdc-e695-4683-a86b-ede613f37569',N'ThS.BS',N'Bác sĩ Nguyễn Hồng Vân Khánh là bác sĩ Nhi khoa giỏi tại Thành phố Hồ Chí Minh. Hiện Bác sĩ Vân Khánh đang công tác tại Bệnh viện Nhi Đồng 2. Bác sĩ Nguyễn Hồng Vân Khánh chuyên khám và điều trị các bệnh lý về tiêu hóa, gan mật, tư vấn dinh dưỡng cho nhi.','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);
INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('ed545e96-3617-455e-a022-f3e6ec1b7ae6',N'ThS.BS',N'Thạc sĩ Bác sĩ CHẾ THỊ ÁNH TUYẾT -  hiện đang là trưởng khoa Nhi bệnh viện đa khoa Hoàn Mỹ Đà Lạt với trên 20 năm kinh nghiệm và hiện đang trực tiếp khám bệnh điều trị tại bệnh viện, cũng như là chủ cơ sở Phòng khám TUYẾT TRUNG tại 151 Phan Chu Trinh, P.9, TP. Đà Lạt.','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);
INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('bc80e305-297b-4112-bc9b-f6125844b878',N'BS.CK1',N'Bác sĩ Chuyên khoa 1 Phan Thị Bạch Tuyết công tác trên 10 năm Bệnh Viện Nhi Đồng 2. - Đang làm tại khoa Sơ Sinh Bệnh Viện Nhi Đồng 2. Bác có nhiều kinh nghiệm tư vấn khám sơ sinh và Nhi tổng quát,các bệnh lý hô hấp,tiêu hoá,tư vấn dinh dưỡng... - Sau khi khám Bác sĩ sẽ tiếp tục theo dõi sức khỏe của bé thông qua việc gọi điện,nhắn tin hỏi thăm.Nhờ đó, bố mẹ luôn được tư vấn cách chăm sóc trẻ, cách xử lý kịp thời khi bé có các dấu hiệu bất thường.','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);
INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('907266cc-baf8-4704-a52c-008c9fb20f3c',N'BS.CK1',N'Bác sĩ Chuyên khoa 1 Lê Trung Dung đã có hơn 20 năm kinh nghiệm trong khám và điều trị trong lĩnh vực Nhi khoa. Bác sĩ Trung Dung hiện tại công tác tại bệnh viện Nhi Đồng 2, từng công tác tại khoa hồi sức, khoa tiêu hoá, nội tổng hợp và điều trị ban ngày.','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);
INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('27f31308-4cc0-4917-912f-01fbe8934529',N'BS.CK2',N'Bác sĩ Chuyên khoa II NGUYỄN DUY TOÀN là nguyên chủ nhiệm khoa Nhi bệnh viện 175 (đã nghỉ hưu), chuyên khoa Nhi với nhiều năm kinh nghiệm, từng đạt danh hiệu Thầy thuốc ưu tú và là Đại tá Bác sĩ Chuyên khoa II.','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);
INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('75e8c74e-0847-4ed1-871c-03e537bef987',N'BS.CK1',N'BS.CK1 Phạm Minh Trường là chuyên gia thẩm mỹ nội khoa, đặc biệt trong lĩnh vực điều trị nám da, với hơn 11 năm kinh nghiệm. Bác sĩ Trường luôn là cái tên được rất nhiều đồng nghiệp trong giới nể trọng và là “bạn đồng hành” của những tên tuổi ngôi sao','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);
INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('1e7dc4c2-cee6-44c4-b24c-0a8f54e37d5d',N'TS.BS',N'Tiến sĩ - Bác sĩ Trần Ngọc Ánh đã có hơn 30 năm kinh nghiệm trong ngành Da liễu. Bác sĩ Ánh là Nguyên giảng viên Bộ môn Da liễu, Trường Đại học Y khoa Phạm Ngọc Thạch TP.HCM, Bệnh viện Da Liễu TP.HCM. Bác sĩ Trần Ngọc Ánh luôn học hỏi không ngừng để nâng cao tay nghề bằng việc thường xuyên tham gia cập nhật kiến thức mới qua các lớp học, hội nghị, hội thảo trong và ngoài nước.','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);
INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('e84cad00-8b27-4077-8f12-0dd69a43ff79',N'BS',N'Là một bác sĩ giỏi, nổi tiếng và có chuyên môn cao trong việc điều trị các bệnh về da liễu ở cả người lớn và trẻ em. Bác sĩ luôn giữ tác phong chuyên nghiệp và thường xuyên cập nhật những kiến thức mới nhất về y khoa trong việc phát hiện triệu chứng, xác định bệnh, điều trị và tư vấn điều trị một cách hiệu quả nhất tính trạng mà bệnh nhân đang gặp phải. Ngoài ra bác sĩ bích ngọc cũng luôn đòi hỏi người bệnh phải kiên trì trong việc chữa trị, tránh bỏ dở giữa chừng mà bệnh thành mãn tính và lâu khỏi.','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);
INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('bb8717c3-4868-4b1c-9200-15e1f7c29779',N'BS.CK1',N'BS Phước là Nguyên BS Bệnh viện Da Liễu TP Hồ Chí Minh với nhiều năm kinh nghiệm, tận tụy, tâm huyết với nghề. Hiện đang là Trưởng khoa Da Liễu Bệnh viện C Đà Nẵng. Chuyên điều trị các bệnh da liễu, điều trị mụn, sẹo rỗ, làm đẹp da bằng mỹ phẩm, laser, phi kim... Phòng khám tiên phong đi đầu trong việc ứng dụng các công nghệ mới nhất trong chăm sóc da với giá cả phù hợp.','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);
INSERT INTO [DoctorProfiles] (ProfileID,Title,Description,WorkStart,SpecializationID,Quality)
VALUES ('ed18c0f2-82bc-46f7-b675-16e71b7b6ee9',N'BS',N'6 năm kinh nghiệm trong lĩnh vực Da liễu. Khám và điều trị các vấn đề liên quan đến da và phần phụ của da (lông, tóc, móng).','01/01/2001','e360722f-7405-4278-a4b2-17497036cef0',5);

GO

INSERT INTO [EmployeeProfiles] (ProfileID,WorkStart,Description)
VALUES ('4a015601-0c67-44c8-b15c-09795b44686e','01/01/2001',N'Admin dùng để test.');
INSERT INTO [EmployeeProfiles] (ProfileID,WorkStart,Description)
VALUES ('f1e1af4d-1349-4eeb-8038-32ee053905a6','01/01/2001',N'Admin.');
INSERT INTO [EmployeeProfiles] (ProfileID,WorkStart,Description)
VALUES ('cb643bd1-9674-402f-b449-1ac6282e1669','01/01/2001',N'Admin.');
INSERT INTO [EmployeeProfiles] (ProfileID,WorkStart,Description)
VALUES ('beaba080-353b-4e4a-9966-2dad1032a749','01/01/2001',N'Admin.');
INSERT INTO [EmployeeProfiles] (ProfileID,WorkStart,Description)
VALUES ('dcb023a8-fd35-439b-8011-3d20e6a420e7','01/01/2001',N'Admin.');
INSERT INTO [EmployeeProfiles] (ProfileID,WorkStart,Description)
VALUES ('536f3d8c-adad-49b6-b799-3f5552a8aed1','01/01/2001',N'Admin.');
INSERT INTO [EmployeeProfiles] (ProfileID,WorkStart,Description)
VALUES ('003a894b-36a8-4471-b906-dc627a6ce9c2','01/01/2001',N'Expert Khang.');

INSERT INTO [EmployeeProfiles] (ProfileID,WorkStart,Description)
VALUES ('5be2d966-3030-494c-8bec-2f7181bc4fc6','01/01/2001',N'Tư vấn viên dùng để test.');
INSERT INTO [EmployeeProfiles] (ProfileID,WorkStart,Description)
VALUES ('2692cf87-ade0-419a-85b3-a1c2a3c44968','01/01/2001',N'Tư vấn viên ưu tú.');
INSERT INTO [EmployeeProfiles] (ProfileID,WorkStart,Description)
VALUES ('afe0f9a1-05ff-42cb-bc27-b2f352b8b684','01/01/2001',N'Tư vấn viên ưu tú.');
INSERT INTO [EmployeeProfiles] (ProfileID,WorkStart,Description)
VALUES ('f41241e2-71a8-4ffc-b306-bc2f20d7ab53','01/01/2001',N'Tư vấn viên ưu tú.');
INSERT INTO [EmployeeProfiles] (ProfileID,WorkStart,Description)
VALUES ('c8a431b9-c2c2-47cf-a169-c219d3b7607a','01/01/2001',N'Tư vấn viên ưu tú.');
INSERT INTO [EmployeeProfiles] (ProfileID,WorkStart,Description)
VALUES ('73070972-e93b-4dd2-9d6d-c7022759052e','01/01/2001',N'Tư vấn viên ưu tú.');

GO

INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('e1d2bbb8-d3ac-4806-bc85-41a2630433e9','AB-',170,70,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('6946f661-40d9-45e7-8527-5045522dd8c5','AB+',160,50,'6a213e3d-6121-490e-87fc-747ba820491e');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('9132f03d-c300-4725-b35a-7e364631eb7c','A-',155,55,'c956e62b-5709-4a4a-85b0-6a3452b48abf');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('d88c45d5-382a-4a86-977c-8092c14e83f9','B-',165,50,'7cb6ef5f-648a-477a-9172-5172ff4f7868');

INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('45a9d235-0845-42e8-854b-ca62ac06ba0e','A-',170,75,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('bbb518fe-c93d-4845-ab2b-db4bb8aa964f','A+',175,65,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('77942dd9-ad18-49f2-8d4a-f0d7ecd616fd','B-',170,75,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('245cd364-da20-4cc9-b97c-f659a4c73f8a','B-',168,55,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('9b5a9fab-8f64-449e-bd5d-ff9bba314431','AB+',170,60,'13accb41-1cad-4171-85aa-f3d76464c3dc');

INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('35c78e79-f9ff-4d18-87a1-70a206e6fddb','AB-',170,75,'84251a89-a458-46f8-ba28-83df593ed2a9');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('e09510d0-98a0-47f9-a332-73cb75742b0b','O+',175,65,'6a213e3d-6121-490e-87fc-747ba820491e');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('874e674c-7cc1-4551-8a58-75f2378f9aa7','O-',170,75,'7cb6ef5f-648a-477a-9172-5172ff4f7868');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('293d15fa-12e0-4408-b194-8312375bcaaa','A-',168,55,'ebfd7919-7210-4c54-bb76-fa37dcc191a3');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('e07f41eb-00b0-4dc3-8c08-98c02956d4e7','A+',170,60,'c956e62b-5709-4a4a-85b0-6a3452b48abf');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('d67add11-294e-464d-8809-a9ae3194109a','B+',170,75,'6a213e3d-6121-490e-87fc-747ba820491e');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('2ad38fef-416b-401d-8885-b719cdabc0fa','B-',175,65,'c956e62b-5709-4a4a-85b0-6a3452b48abf');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('488de21c-8552-468e-b293-cbbfea3ba55b','AB-',170,75,'c956e62b-5709-4a4a-85b0-6a3452b48abf');

INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('350af705-bd31-40ab-8b0f-3a064d4e3df9','A+',165,55,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('ac9c04ad-885e-4c73-b035-3e53b5e34284','A-',160,47,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('295c36f4-54d7-4183-b6b1-450054047200','A+',162,58,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('cd3e7605-81ac-4a97-9ca3-58ed958fb4b6','B-',168,60,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('ca44f559-803f-4daf-b024-9c870c62318e','B-',157,62,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('6ac68c37-0ae3-478f-9c22-9cf22fa3db1c','B+',170,51,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('9ad897ac-89d2-4ef0-be64-a7d58dfd5f8d','AB+',169,50,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('f2427dc3-481e-4e31-8f81-d06526bdaf58','AB-',163,58,'13accb41-1cad-4171-85aa-f3d76464c3dc');

INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('1e7028e1-356c-429b-b5e1-1b6b130d5871','A+',165,55,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('9a910220-9883-4b23-b0e2-1ecab6c46275','A-',160,47,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('81a9cc52-7b67-4a61-8bcc-3782be771fce','A+',162,58,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('57d380f2-9ce4-4d07-9100-37b0dc0e32af','B-',168,60,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('0231f164-2680-42f5-84fb-5f07428eaddd','B+',157,62,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('f3575ab5-1d36-426c-888c-6415324c3f0d','B-',170,51,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('4b6f23f7-a4e2-47d8-a933-83d52ba8d9b7','AB+',169,50,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('bde3df23-94a5-4d12-8342-07307ceca903','AB-',163,58,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('a0bccb90-a68c-42c1-bf36-2a20f85a6fb0','AB-',159,50,'13accb41-1cad-4171-85aa-f3d76464c3dc');
INSERT INTO [HealthProfiles] (ProfileID,BloodType,Height,Weight,RelationshipID)
VALUES ('2590134e-c741-405e-ba2a-2be38a27d8bc','AB+',155,49,'13accb41-1cad-4171-85aa-f3d76464c3dc');



GO
