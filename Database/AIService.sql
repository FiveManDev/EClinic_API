CREATE DATABASE AIService
GO
USE [AIService]

GO
CREATE TABLE "MachineLearning"(
    "MachineID" uniqueidentifier NOT NULL DEFAULT NewID(),
    "MachineName" VARCHAR(255) NOT NULL
);
ALTER TABLE
    "MachineLearning" ADD CONSTRAINT "machinelearning_machineid_primary" PRIMARY KEY("MachineID");
CREATE TABLE "Model"(
    "ModelID" uniqueidentifier NOT NULL DEFAULT NewID(),
    "FileURL" VARCHAR(255) NOT NULL,
    "Accuracy" FLOAT NOT NULL,
    "IsActive" BIT NOT NULL,
    "CreatedAt" DATETIME NOT NULL,
    "UpdatedAt" DATETIME NOT NULL,
    "MachineID" uniqueidentifier NOT NULL,
    "DeepID" uniqueidentifier NOT NULL
);
ALTER TABLE
    "Model" ADD CONSTRAINT "model_modelid_primary" PRIMARY KEY("ModelID");
CREATE TABLE "DeepLearning"(
    "DeepID" uniqueidentifier NOT NULL DEFAULT NewID(),
    "DeepName" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "DeepLearning" ADD CONSTRAINT "deeplearning_deepid_primary" PRIMARY KEY("DeepID");
CREATE TABLE "PredictionHistory"(
    "PredictID" uniqueidentifier NOT NULL DEFAULT NewID(),
    "Note" NVARCHAR(255) NOT NULL,
    "Result" VARCHAR(255) NOT NULL,
    "PredictTime" DATETIME NOT NULL,
    "ModelID" uniqueidentifier NOT NULL
);
ALTER TABLE
    "PredictionHistory" ADD CONSTRAINT "predictionhistory_predictid_primary" PRIMARY KEY("PredictID");
ALTER TABLE
    "PredictionHistory" ADD CONSTRAINT "predictionhistory_modelid_foreign" FOREIGN KEY("ModelID") REFERENCES "Model"("ModelID");
ALTER TABLE
    "Model" ADD CONSTRAINT "model_machineid_foreign" FOREIGN KEY("MachineID") REFERENCES "MachineLearning"("MachineID");
ALTER TABLE
    "Model" ADD CONSTRAINT "model_deepid_foreign" FOREIGN KEY("DeepID") REFERENCES "DeepLearning"("DeepID");
GO

INSERT INTO [dbo].[DeepLearning]([DeepID],[DeepName])
VALUES ('cdf2376e-d944-4d54-8faa-00c43398368b','ResNet-50')
INSERT INTO [dbo].[DeepLearning]([DeepID],[DeepName])
VALUES ('46159922-0175-4408-80b2-68f0ef8f2f6a','VGG16')
INSERT INTO [dbo].[DeepLearning]([DeepID],[DeepName])
VALUES ('0f9f2229-b411-4d7b-a88c-f7d007215fd9','MobileNet')

GO

INSERT INTO [dbo].[MachineLearning]([MachineID],[MachineName])
VALUES ('a9351300-ef9a-441c-8c9d-048f0aa109ac','Random Forest Classification')
INSERT INTO [dbo].[MachineLearning]([MachineID],[MachineName])
VALUES ('84fc935e-ef19-4417-93f3-16634097ebac','K-Nearest Neighbors')
INSERT INTO [dbo].[MachineLearning]([MachineID],[MachineName])
VALUES ('f0c4aeaa-bb06-4927-821b-1b55fd1ecc11','Gaussian Naive Bayes')
INSERT INTO [dbo].[MachineLearning]([MachineID],[MachineName])
VALUES ('0aefd695-d080-4f2f-8b87-76d9864d3b6d','Decision Tree Classification')
INSERT INTO [dbo].[MachineLearning]([MachineID],[MachineName])
VALUES ('4056e726-c9fa-4f3f-be00-c84f79dc3609','Logistic Regression')
INSERT INTO [dbo].[MachineLearning]([MachineID],[MachineName])
VALUES ('4745a160-f27d-4fd4-af4b-d162fb9bfc73','AdaBoost Classifier')