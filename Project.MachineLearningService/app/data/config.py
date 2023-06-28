from data.db import ModelRepository
mongo_url = "mongodb://localhost:27017"
db_name = "MachineLearningService"
collection_name = "Model"
repository = ModelRepository(mongo_url, db_name, collection_name)