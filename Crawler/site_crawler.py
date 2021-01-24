import requests
from bs4 import BeautifulSoup
from requests_html import HTMLSession
import sqlite3
from sqlite3 import Error
import database
import module_crawler

def get_award(title):
    award = title.split("\xa0")[0]
    return award

def get_scheme_id(title):
    scheme_id = title.split("[")[1]
    scheme_id = scheme_id[:-1]
    print(scheme_id)
    return scheme_id

def get_title(title):
    title = title.split("\xa0")[1]
    title = title.split(" [")[0]
    return title

def format_duration(duration):
    duration = duration.split(": ")[1]
    return int(duration[0])

def get_post_or_under_grad(post_or_under):
    if("Undergraduate Study Schemes" in post_or_under):
        return "Undergraduate"
    elif("Postgraduate Study Schemes" in post_or_under):
        return "Postgraduate"

def get_academic_year(year):
    return year.split(": ")[1]

def is_core(title):
    if "Timetable Core" in title:
        return "Core Option"
    elif "Core" in title:
        return "Core"
    elif "Option" in title:
        return "Option"
    elif "Electives" in title:
        return "Electives"


session = HTMLSession()
modules_url_head = 'https://www.aber.ac.uk/en/modules/deptfuture/'
# module_crawler.get_modules(modules_url_head,conn)

department_url_head = "https://www.aber.ac.uk/en/study-schemes/deptfuture/"
main_session = session.get(department_url_head)
content_element = main_session.html.find('div.content.ue',first=True)
departments = content_element.find('a')




# for department in departments:
#     url = department.attrs['href']
#     department_session = session.get(department_url_head + department.attrs['href'])
#     main_content = department_session.html.find('div.content.ue')[0].find()
#     post_or_under = ""
#     scheme_type = ""
#     a = ""
    # for element in main_content:
    #     if(element.tag=='h3'):
    #         post_or_under = get_post_or_under_grad(element.text)
    #     elif(element.tag=='h4'):
    #         scheme_type = element.text
    #     elif(element.tag=='a'):
    #         a = element.attrs['href']
    #         scheme_url = department_url_head+url+a
    #         scheme_session = session.get(scheme_url).html
    #         full_title = scheme_session.find("h2",first=True).text
    #         award = get_award(full_title)
    #         title = get_title(full_title)
    #         scheme_id = get_scheme_id(full_title)
    #         year =  scheme_session.find("span.ac_year",first=True).text
    #         year = get_academic_year(year)
    #         duration = scheme_session.find("p")[3].text
    #         duration =format_duration(duration)
    #         scheme = [scheme_id,title,award,department.text,post_or_under,scheme_type,duration,year,scheme_url]
    #         if(database.check_if_scheme_exists(conn,scheme[0]) == False):
            #     database.create_scheme(conn, scheme)            
            # else:
            #     print("Already Exists")
            
            # scheme_rule_data = scheme_session.find("div.content.ue",first=True)
            # core = ""

            # for html_element in scheme_rule_data.find():
            #     if "class" in html_element.attrs:
            #         div_class  = html_element.attrs["class"][0]
            #         if(div_class=="schemes-x-year-options"):
            #             # part_type_title = html_element.find("h3",first=True)
            #             # if part_type_title:
            #             #     print(part_type_title.text)
            #             credit_type_title = html_element.find("h4",first=True)
            #             if credit_type_title:
            #                 core = is_core(credit_type_title.text)
                            
            #         elif(div_class=="scheme-twocol-x-both-cols"):
            #             col1 = html_element.find("div.scheme-twocol-x-col.scheme-twocol-x-col1",first=True)
            #             col2 = html_element.find("div.scheme-twocol-x-col.scheme-twocol-x-col2",first=True)
            #             if col1 :
            #                 sesester1 = col1.find("strong",first=True)
            #                 modules_list = col1.find("a")
            #                 for m in modules_list:
            #                     print(core)
            #                     sche = m.text+"_"+scheme_id
            #                     print(sche)
            #                     database.create_scheme_module(conn,[m.text,scheme_id,core])
            #             elif  col2 :
            #                 sesester2 = col2.find("strong",first=True)
            #                 modules_list = col2.find("a")
            #                 for m in modules_list:
            #                         database.create_scheme_module(conn,[m.text,scheme_id,core])