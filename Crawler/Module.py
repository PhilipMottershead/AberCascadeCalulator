from mongoengine import StringField,Document,URLField,IntField,BooleanField

class Module(Document):
    _id = StringField(required=True)
    title = StringField(required=True)
    coordinator = StringField(max_length=50)
    semester = StringField(max_length=50)
    year = StringField(max_length=50)
    department = StringField(max_length=50)
    prefix = StringField(max_length=50)
    module_credits = StringField()
    welsh = BooleanField()
    url = URLField()