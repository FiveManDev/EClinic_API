CREATE DATABASE AIService
GO
USE [AIService]

GO
CREATE TABLE "MachineLearning"(
    "MachineID" uniqueidentifier NOT NULL,
    "MachineName" VARCHAR(255) NOT NULL
);
ALTER TABLE
    "MachineLearning" ADD CONSTRAINT "machinelearning_machineid_primary" PRIMARY KEY("MachineID");
CREATE TABLE "Model"(
    "ModelID" uniqueidentifier NOT NULL,
    "FIleURL" VARCHAR(255) NOT NULL,
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
    "DeepID" uniqueidentifier NOT NULL,
    "DeepName" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "DeepLearning" ADD CONSTRAINT "deeplearning_deepid_primary" PRIMARY KEY("DeepID");
CREATE TABLE "PredictionHistory"(
    "PredictID" uniqueidentifier NOT NULL,
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