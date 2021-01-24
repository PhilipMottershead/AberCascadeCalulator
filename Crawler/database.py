import sqlite3
import mongoengine
from mongoengine import StringField,Document,URLField,IntField,BooleanField
mongoengine.connect('AberCascade')

class Module(Document):
    module_id = StringField()
    title = StringField()
    coordinator = StringField()
    semester = StringField()
    year = StringField()
    department = StringField()
    prefix = StringField()
    session = StringField()
    module_credits = IntField()
    welsh = BooleanField()
    url = URLField()

def create_module(res:dict):
    module = Module()
    if(res['welsh']==True):
        module.title = res['Teitl y Modiwl']
        module._id = res['Cod y Modiwl']
        module.coordinator = res['Cyd-gysylltydd y Modiwl']
    else:
        module.title = res['Module Title']
        module._id = res['Module Identifier']
        module.coordinator = res['Co-ordinator']
    module.semester = res['Semester']
    module.session = res['session']
    module.year = res['year']
    module.department = res['department']
    module.prefix = res['prefix'] 
    module.module_credits=res['credits']
    module.welsh = res['welsh']
    module.url= res['url']
    module.save()
