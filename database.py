import sqlite3
from sqlite3 import Error

sql_create_module_table = """ CREATE TABLE IF NOT EXISTS module (
                                        module_id text PRIMARY KEY,
                                        title text,
                                        coordinator text,
                                        semester text,
                                        year text,
                                        department text,
                                        credits interger,
                                        welsh bool
                                    ); """

def create_module_table(conn):
    create_table(conn,sql_create_module_table)

def create_connection(db_file):
    """ create a database connection to the SQLite database
        specified by db_file
    :param db_file: database file
    :return: Connection object or None
    """
    conn = None
    try:
        conn = sqlite3.connect(db_file)
        return conn
    except Error as e:
        print(e)

    return conn

def create_table(conn, create_table_sql):
    """ create a table from the create_table_sql statement
    :param conn: Connection object
    :param create_table_sql: a CREATE TABLE statement
    :return:
    """
    try:
        c = conn.cursor()
        c.execute(create_table_sql)
    except Error as e:
        print(e)

def create_module(conn, module):
    """
    Create a new project into the projects table
    :param conn:
    :param project:
    :return: project id
    """
    sql = ''' INSERT INTO module(module_id,title,coordinator,semester,year,department,credits,welsh)
              VALUES(?,?,?,?,?,?,?,?) '''
    cur = conn.cursor()
    print(module[0])

    cur.execute(sql, module)
    conn.commit()
    return cur.lastrowid

def check_if_module_exists(conn, id):
    retur = conn.execute('SELECT * FROM module WHERE module_id = "%s"'%id)  
    if len(retur.fetchall())>0 :
        return True
    else:
        return False

# database_url = r"/home/philip/Cascade/cascade.db"
# conn = create_connection(database_url)

