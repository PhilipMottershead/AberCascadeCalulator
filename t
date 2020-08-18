 if url==learn_welsh or url == lifelong_Learning or url == english:
        print("ignore")
    elif url == vet:
        vet_schemes(session)
    elif url == dis:
        dis_schemes()
    elif url == "/en/tfts/":
        ug_url="https://www.aber.ac.uk/en/tfts/study-with-us/prosp-ug/"
        pg_url="https://www.aber.ac.uk/en/tfts/study-with-us/postgrad/"
        subject_session = session.get(ug_url)
        s = subject_session.html.find("div.course-search-listing.list-listing")[0]
        ass = s.find("a")
        for a in ass:
            insert_into_database(a)

            
    elif url == "/en/modernlangs/":
        boxes = department_session.html.find("div.feature-box-image")
        box1 = find_box(boxes,"Undergraduate courses","h2")
        box2 = find_box(boxes,"Postgraduate courses","h2")
        undergrad_url = "http:"+box1.find("a")[0].attrs['href']
        print("http:"+box2.find("a")[0].attrs['href'])
        subject_session = session.get(undergrad_url)

        s = subject_session.html.find("div.course-search-listing.list-listing")[0]
        ass = s.find("a")
        for a in ass:
            insert_into_database(a)

    else:
        boxes = department_session.html.find("div.feature-box-image")
        box1 = find_box(boxes,"Undergraduate courses","h2")
        box2 = find_box(boxes,"Postgraduate courses","h2")
        undergrad_url = box1.find("a")[0].attrs['href']
        postgrad_url = box2.find("a")[0].attrs['href']

        subject_session = session.get(undergrad_url)
        subject_list = subject_session.html.find("ul.list-link-menu")
        if (len(subject_list)!=0):
            get_scheme_multi_subject(undergrad_url)
            get_scheme_single_subject(postgrad_url)
        else:
            get_scheme_single_subject(undergrad_url)
            get_scheme_single_subject(postgrad_url)

            def get_scheme_multi_subject(url):
    subject_session = session.get(url)
    subject_list = subject_session.html.find("ul.list-link-menu")
    if (len(subject_list)!=0):
        for li in subject_list[0].find("li"):
            url = li.find("a")[0].attrs['href']
            scheme_session = session.get(department_head + url)
            single = sschemes_listheme_session.html.find("a")
            for s in single:
                insert_into_database(s)
                get_module(s)

def insert_into_database(s):
    title = s.attrs["title"]
    scheme_title = get_title(s.attrs["title"])
    year = get_year(s.attrs["href"])
    award = get_award(s.attrs["title"])
    scheme_id = get_scheme_id(s.attrs["title"])
    scheme = [scheme_id,scheme_title,award,department.text,year]
    if(database.check_if_scheme_exists(conn,scheme[0]) == False):
        database.create_scheme(conn,scheme)
    else:
        print("Error",scheme)

def get_scheme_single_subject(url):
    if(url[0]=="/"):
        url = "http:" + url
    subject_session = session.get(url)
    s = subject_session.html.find("div.course-search-listing.list-listing")
    if len(s) > 0:
        ass = s[0].find("a")
        for a in ass:
            insert_into_database(a)