import requests
from bs4 import BeautifulSoup
from requests_html import HTMLSession
import sqlite3
from sqlite3 import Error
import database

session = HTMLSession()

def get_year(id):
    split = id[2:3]
    return split

def get_credits(id):
    split = id[5:]
    return int(split)

def get_departmentCode(id):
    split = id[0:1]
    return split

def get_moduleCode(id):
    split = id[3:5]
    return split

def get_semester(semester_string):
    if semester_string == "Semester 1":
        return 1
    elif semester_string == "Semester 2":
        return 2
    elif semester_string == "Semester 1 (Taught over 2 semesters)":
        return 1
    else:
        print(semester_string)

def get_module_info(url, department):
    module_session = session.get(url)
    module1 = []
    module_data = module_session.html.find("div.module-x-container",first=True)
    key = module_data.find("div.module-x-column-left")
    value = module_data.find("div.module-x-column-right")
    
    key = [key[i].text for i in range(len(key))]
    value = [value[i].text for i in range(len(value))]
    year = get_year(value[0])
    num_credits = get_credits(value[0])
    key.append("year")
    key.append("credits")
    value.append(year)
    value.append(num_credits)
    
    res = {key[i]: value[i] for i in range(len(key))}   
    
    if key[0]=="Cod y Modiwl":
        module1 = [res['Cod y Modiwl'],res['Teitl y Modiwl'],res['Cyd-gysylltydd y Modiwl'],res['Semester'],res['year'],department.text,res['credits'],True,url]
    else:
        module1 = [res['Module Identifier'],res['Module Title'],res['Co-ordinator'],res['Semester'],res['year'],department.text,res['credits'],False,url]
    
    return module1

def get_modules(url_head,conn):
    main_session = session.get(url_head)
    content_element = main_session.html.find('div.content.ue')[0]
    department_element_list =content_element.find("a")

    for department in department_element_list:
        department_url = url_head + department.attrs['href']
        department_session = session.get(department_url)
        content_department = department_session.html.find('div.content.ue')[0]
        module_links =content_department.find("div")[0].links
        module_urls = []
        for link in module_links:
            module_urls.append(department_url+link)
        for url in module_urls:
            module = get_module_info(url,department)
            if(database.check_if_module_exists(conn,module[0]) == False):
                database.create_module(conn,module)
            else:
                print("Error")