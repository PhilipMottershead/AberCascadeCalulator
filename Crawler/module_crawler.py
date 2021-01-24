from requests_html import HTMLSession
import requests
import pymongo_database
from multiprocessing import Pool
import time
import progressbar
session = HTMLSession()
business_prefix_list = ["AB", "AC", "CB", "EC", "MB", "MM", "MR", "CG", "EU", "EW"]
art_prefix_list = ["AH", "AR", "XD", "XA", "XK", "MG"]
ibers_prefix_list = ["BB", "BD", "BG", "BR", "RD", "RG", "SS", "BS", "BC", "GT", "RS", "AG"]
careers_prefix_list = ["CD"]
compsci_prefix_list = ["CO", "CC", "CS", "CH", "SE", "CI"]
education_prefix_list = ["AD", "ED"]
english_prefix_list = ["CL", "EN","WL","WR","AS"]
geography_prefix_list = ["DA","EA","GG","GS","ES","WS","BY"]
graduate_prefix_list = ["MO","PG"]
history_prefix_list = ["HA","HC","HP","HQ","HY","WH"]
is_prefix_list = ["PD","DS","IL"]
english_center_prefix_list = ["IC"]
interpol_prefix_list = ["GQ","GW","IP","IQ","SA"]
law_prefix_list = ["CR","CT","LA","LC","LD","GF"]
lifelong_prefix_list = ["YF"]
maths_prefix_list = ["MA","MP","MT","LS","MX"]
languages_prefix_list = ["EL","FR","GE","IT","SP","FF"]
physics_prefix_list = ["FG","PH","PM","PX"]
psychology_prefix_list = ["PS","SC"]
theatre_prefix_list = ["FM","TC","TF","TP","MU","DD","FT","DR","MC","PF","SG"]
welsh_prefix_list = ["CY","IR","LL","WE","GC","OC","CF","MW","GB","YA"]
other_prefix_list = ["QQ","MU","CE"]


def match_department(prefix):
    if(prefix in business_prefix_list):
        return 'Aberystwyrequests_htmlth Business School'
    elif(prefix in art_prefix_list):
        return 'Art'
    elif(prefix in ibers_prefix_list):
        return 'Biological, Environmental and Rural Sciences'
    elif(prefix in careers_prefix_list):
        return 'Careers'
    elif(prefix in compsci_prefix_list):
        return 'Computer Science'
    elif(prefix in education_prefix_list):
        return 'Education'
    elif(prefix in english_prefix_list):
        return 'English and Creative Writing'
    elif(prefix in geography_prefix_list):
        return 'Geography and Earth Sciences'
    elif(prefix in graduate_prefix_list):
        return 'Graduate School'
    elif(prefix in history_prefix_list):
        return 'History and Welsh History'
    elif(prefix in is_prefix_list):
        return 'Information Services'
    elif(prefix in english_center_prefix_list):
        return 'International English Centre'
    elif(prefix in interpol_prefix_list):
        return 'International Politics'
    elif(prefix in law_prefix_list):
        return 'Law & Criminology'
    elif(prefix in lifelong_prefix_list):
        return 'Lifelong Learning'
    elif(prefix in maths_prefix_list):
        return 'Mathematics'
    elif(prefix in languages_prefix_list):
        return 'Modern Languages'
    elif(prefix in physics_prefix_list):
        return 'Physics'
    elif(prefix in psychology_prefix_list):
        return 'Psychology'
    elif(prefix in theatre_prefix_list):
        return 'Theatre, Film and Television Studies'
    elif(prefix in welsh_prefix_list):
        return 'Welsh'
    elif prefix in other_prefix_list:
        return 'Other'
    else:
        return 'Error'


def check_previous_prefix():
    date = 2009
    end = 2021
    with Pool(12) as p:
        p.map(parse_year, [2009,2010,2011,2012,2013,2014,2015,2016,2017,2018,2020,2021])


def parse_year(date):
    url = "https://www.aber.ac.uk/en/modules/"+str(date)+"/index"
    module_session = session.get(url)

    module_data = module_session.html.find("div.module-code-x-25")      
    # else:
    #     url = "https://www.aber.ac.uk/modules-archive/"+str(date)
    #     module_session = session.get(url)
    # module_data = module_session.html.find("a")
    index = 0
    for data in progressbar.progressbar(module_data):
        module_id = data.text
        module_url = "https://www.aber.ac.uk/en/modules/" + str(date) + "/" + module_id + "/"
        get_module_info(module_url, date)
        print(str(index)+"/"+str(len(module_data)))
        index = index + 1


def get_prefix(id):
    split = id[:2]
    return split


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


def get_module_info(url, session_year):
    module_session = session.get(url)
    module_data = module_session.html.find("div.module-x-container", first=True)
    if(module_data is not None):
        key = module_data.find("div.module-x-column-left")
        value = module_data.find("div.module-x-column-right")
        key = [key[i].text for i in range(len(key))]
        value = [value[i].text for i in range(len(value))]
        year = get_year(value[0])
        num_credits = get_credits(value[0])
        prefix = get_prefix(value[0])
        res = {}
        object_id = value[0] + "_" + str(session_year)
        res["_id"] = object_id
        res["year"] = year
        res["credits"] = num_credits
        if key[0] == "Cod y Modiwl":
            res["welsh"] = True
        else:
            res["welsh"] = False
        res["url"] = url
        res["department"] = match_department(prefix)
        res["prefix"] = prefix
        res["module_identifier"] = value[0]
        res["module_title"] = value[1]
        res["academic_year"] = value[2]
        res["co-ordinator"] = value[3]
        res["semester"] = value[4]
        if(not pymongo_database.check_if_module_exists(object_id)):
            # requests.post("http://127.0.0.1:5000/modules/", json=res)
            pymongo_database.create_module(res)
# def get_modules(url_head):
#     main_session = session.get(url_head)
#     content_element = main_session.html.find('div.content.ue')[0]
#     department_element_list =content_element.find("a")
#     module_num = 0
#     department_num = 0

#     for department in department_element_list:
#         department_url = url_head + department.attrs['href']
#         department_session = session.get(department_url)
#         content_department = department_session.html.find('div.content.ue')[0]
#         module_links =content_department.find("div")[0].links
#         module_urls = []
#         for link in module_links:
#             module_urls.append(department_url+link)
#         for url in module_urls:
#             module = get_module_info(url,department)
#             # if(database.check_if_module_exists(conn,module[0]) == False):
#             database.create_module(module)
#             # else:
#                 # print("Module Exists")
#             module_num = module_num + 1
#             print(str(module_num)+"/"+str(len(module_urls)))
#         module_num =0 
#         department_num = department_num +1
#         print(str(department_num)+ "/"+str(len(department_element_list)))


modules_url_head = 'https://www.aber.ac.uk/en/modules/deptfuture/'
# get_modules(modules_url_head)
check_previous_prefix()
