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
                                        welsh bool,
                                        url text
                                    ); """

sql_create_scheme_table = """ CREATE TABLE IF NOT EXISTS scheme (
                                        scheme_id text PRIMARY KEY,
                                        title text,
                                        award text,
                                        department text,
                                        undergraduate_or_postgraduate text,
                                        scheme_type text,
                                        year interger,
                                        duration interger,
                                        url text
                                    ); """

sql_create_scheme_module_table = """ CREATE TABLE IF NOT EXISTS scheme_module (
                                        scheme_module_id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        scheme_id text, 
                                        module_id text,
                                        module_type text,
                                        FOREIGN KEY (scheme_id) REFERENCES scheme(scheme_id),
                                        FOREIGN KEY (module_id) REFERENCES module(module_id)
                                    ); """


def create_module_table(conn):
    create_table(conn,sql_create_module_table)

def create_scheme_table(conn):
    create_table(conn,sql_create_scheme_table)

def create_scheme_module_table(conn):
    create_table(conn,sql_create_scheme_module_table)


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
    sql = ''' INSERT INTO module(module_id,title,coordinator,semester,year,department,credits,welsh,url)
              VALUES(?,?,?,?,?,?,?,?,?) '''
    cur = conn.cursor()
    print(module[0])

    cur.execute(sql, module)
    conn.commit()
    return cur.lastrowid

def create_scheme(conn, scheme):
    """
    Create a new project into the projects table
    :param conn:
    :param project:
    :return: project id
    """
    sql = ''' INSERT INTO scheme(scheme_id,title,award,department,undergraduate_or_postgraduate,scheme_type
,duration,year,url) VALUES(?,?,?,?,?,?,?,?,?) '''
    cur = conn.cursor()
    cur.execute(sql, scheme)
    conn.commit()
    return cur.lastrowid

def create_scheme_module(conn, scheme_module):
    """
    Create a new project into the projects table
    :param conn:
    :param project:
    :return: project id
    """
    sql = ''' INSERT INTO scheme_module(scheme_id,module_id,module_type)
              VALUES(?,?,?) '''
    cur = conn.cursor()
    print(scheme_module)
    cur.execute(sql, scheme_module)
    conn.commit()
    return cur.lastrowid


def check_if_module_exists(conn, id):
    retur = conn.execute('SELECT * FROM module WHERE module_id = "%s"'%id)  
    if len(retur.fetchall())>0 :
        return True
    else:
        return False

def check_if_scheme_exists(conn, id):
    retur = conn.execute('SELECT * FROM scheme WHERE scheme_id = "%s"'%id)  
    if len(retur.fetchall())>0 :
        return True
    else:
        return False

# database_url = r"/home/philip/Cascade/cascade.db"
# conn = create_connection(database_url)

