from pymongo import MongoClient
from bson.objectid import ObjectId
# client = MongoClient('mongodb://localhost:27017/')
# db = client.AberCascade
# collection = db.module


def check_if_module_exists(id):
    client = MongoClient('mongodb://localhost:27017/')
    db = client.AberCascade
    collection = db.module
    module = collection.find_one({"_id": id})
    if(module is None):
        return False
    return True


def create_module(res):
    client1 = MongoClient('mongodb://localhost:27017/')
    db1 = client1.AberCascade
    collection1 = db1.module

    collection1.insert_one(res)
    return res


def get_modules():
    client = MongoClient('mongodb://localhost:27017/')
    db = client.AberCascade
    collection = db.module
    print(collection.find())
    return list(collection.find())


def get_module(id):
    client = MongoClient('mongodb://localhost:27017/')
    db = client.AberCascade
    collection = db.module
    return collection.find_one({"_id": id})


def delete_module(id):
    client = MongoClient('mongodb://localhost:27017/')
    db = client.AberCascade
    collection = db.module
    collection.delete_one({"_id": ObjectId(id)})
