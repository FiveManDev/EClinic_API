import pymongo
from bson import ObjectId


class ModelRepository:
    def __init__(self, mongo_url, db_name, collection_name):
        try:
            self.client = pymongo.MongoClient(mongo_url)
            self.db = self.client[db_name]
            self.collection = self.db[collection_name]
        except pymongo.errors.ConnectionError as e:
            raise Exception("Failed to connect to MongoDB:", str(e))

    def create(self, data):
        try:
            response = self.collection.insert_one(dict(data))
            if response.inserted_id is None:
                raise Exception("Failed to create document: inserted_id is None")
            return response.inserted_id
        except pymongo.errors.PyMongoError as e:
            raise Exception("Failed to create document:", str(e))

    def all(self):
        try:
            response = self.collection.find({})
            data = []
            for i in response:
                i["_id"] = str(i["_id"])
                i["Time"] = str( i["Time"])
                data.append(i)
            return data
        except pymongo.errors.PyMongoError as e:
            raise Exception("Failed to retrieve documents:", str(e))

    def get_by_id(self, id):
        try:
            obj_id = ObjectId(id)
            response = self.collection.find_one({"_id": obj_id})
            if response:
                response["_id"] = str(response["_id"])
                response["Time"] = str( response["Time"])
                return response
            else:
                return None
        except pymongo.errors.PyMongoError as e:
            raise Exception("Failed to retrieve document by ID:", str(e))

    def update(self, id, data):
        try:
            obj_id = ObjectId(id)
            response = self.collection.update_one({"_id": obj_id}, {"$set": dict(data)})
            if response.modified_count != 1:
                raise Exception("Failed to create document: inserted_id is None")
            return True
        except pymongo.errors.PyMongoError as e:
            raise Exception("Failed to update document:", str(e))

    def delete(self, id):
        try:
            obj_id = ObjectId(id)
            response = self.collection.delete_one({"_id": obj_id})
            if response.deleted_count != 1:
                raise Exception("Failed to create document: inserted_id is None")
            return True
        except pymongo.errors.PyMongoError as e:
            raise Exception("Failed to delete document:", str(e))
