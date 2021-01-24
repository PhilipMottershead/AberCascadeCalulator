from flask import Flask
from flask_restx import Api, Resource, fields
import pymongo_database
app = Flask(__name__)
api = Api(app, version='1.0', title='Aber Modules API',
          description='A API For Aber Modules scraped from the website',
          )

ns = api.namespace('modules', description='Aber Modules operations')

todo = api.model('Todo', {
    '_id': fields.String(readonly=True, description='The object id'),
    'module_identifier': fields.String(required=True,
                                       description='The modules identifier'),
    'module_title': fields.String(required=True, description='The modules title'),
    'department': fields.String(required=True, description='The modules department'),
    'academic_year': fields.String(required=True, description='The academic year the module is taught'),
    'semester': fields.String(required=True, description='The semester module is taught'),
    'credits': fields.Integer(required=True, description='The number of credits for the module'),
    'welsh': fields.Boolean(required=True, description='If the module is in welsh'),
    'url': fields.String(required=True, description='The url for the module page'),
    'prefix': fields.String(required=True, description='The prefix for the module id'),
})

@ns.route('/')
class TodoList(Resource):
    '''Shows a list of all todos, and lets you POST to add new tasks'''
    @ns.doc('list_todos')
    @ns.marshal_list_with(todo)
    def get(self):
        '''List all tasks'''
        return pymongo_database.get_modules()

    @ns.doc('create_todo')
    @ns.expect(todo)
    @ns.marshal_with(todo, code=201)
    def post(self):
        '''Create a new task'''
        return pymongo_database.create_module(api.payload)


@ns.route('/<string:id>')
@ns.response(404, 'Todo not found')
@ns.param('id', 'The task identifier')
class Todo(Resource):
    '''Show a single todo item and lets you delete them'''
    @ns.doc('get_todo')
    @ns.marshal_with(todo)
    def get(self, id):
        '''Fetch a given resource'''
        module = pymongo_database.get_module(id)
        if(module is not None):
            return module
        api.abort(404, "Todo {} doesn't exist".format(id))

    @ns.doc('delete_todo')
    @ns.response(204, 'Todo deleted')
    def delete(self, id):
        '''Delete a task given its identifier'''
        pymongo_database.delete_module(id)
        return '', 204


if __name__ == '__main__':
    app.run(debug=True)
