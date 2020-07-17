import requests
from bs4 import BeautifulSoup
from requests_html import HTMLSession
import sqlite3
from sqlite3 import Error
import database

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
    module_data = module_session.html.find("div.module-x-container")[0]
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
        module1 = [res['Cod y Modiwl'],res['Teitl y Modiwl'],res['Cyd-gysylltydd y Modiwl'],res['Semester'],res['year'],department.text,res['credits'],True]
    else:
        module1 = [res['Module Identifier'],res['Module Title'],res['Co-ordinator'],res['Semester'],res['year'],department.text,res['credits'],False]
    
    return module1

def vet_schemes():
    print("Vet")

def dis_schemes():
    print("Dis")

def find_box(boxes,text):
    for box in boxes:
            if box.find("h2")[0].text == text:
                return box

def get_modules(url_head):
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
            module = get_module_info(url)
            if(database.check_if_module_exists(conn,module[0]) == False):
                database.create_module(conn,module,department)
            else:
                print("Error")
database_url = r"/home/philip/Cascade/cascade.db"
conn = database.create_connection(database_url)
database.create_module_table(conn)

session = HTMLSession()
modules_url_head = 'https://www.aber.ac.uk/en/modules/deptcurrent/'
# get_modules(modules_url_head)
vet = "/en/vet-sci/"
dis = "/en/dis/"
english = "/en/international-english/"
learn_welsh = "/en/learn-welsh/"
lifelong_Learning = "/en/lifelong-learning/"
department_url_head = "https://www.aber.ac.uk/en/departments/"
main_session = session.get(department_url_head)
content_element = main_session.html.find('div.content.ue')[1]
departments = content_element.find('a')
department_head = "https://www.aber.ac.uk"

for department in departments:
    url = department.attrs['href']
    department_session = session.get(department_head+department.attrs['href'])
    if url==learn_welsh or url == lifelong_Learning or url == english:
        print("ignore")
    elif url == vet:
        vet_schemes()
    elif url == dis:
        dis_schemes()
    elif url == "/en/tfts/":
        print("/en/tfts/")
    elif url == "/en/modernlangs/":
        print("http:"+box1.find("a")[0].attrs['href'])
        print("http:"+box1.find("a")[0].attrs['href'])
    else:
        boxes = department_session.html.find("div.feature-box-image")
        box1 = find_box(boxes,"Undergraduate courses")
        box2 = find_box(boxes,"Postgraduate courses")
        undergrad_url = box1.find("a")[0].attrs['href']
        postgrad_url = box2.find("a")[0].attrs['href']

        subject_session = session.get(undergrad_url)
        subject_list = subject_session.html.find("ul.list-link-menu")
        if (len(subject_list)!=0):
            for li in subject_list[0].find("li"):
                url = li.find("a")[0].attrs['href']
                scheme_session = session.get(department_head + url)
                single = scheme_session.html.find("a")
                for s in single:
                    print(s.attrs['title'])

        else:
            for li in subject_session.html.find("li"):
                s = subject_session.html.find("div.course-search-listing.list-listing")[0]
                ass = s.find("a")
                for a in ass:
                    print(a.attrs['title'])
