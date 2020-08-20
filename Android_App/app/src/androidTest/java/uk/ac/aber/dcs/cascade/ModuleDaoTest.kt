package uk.ac.aber.dcs.cascade

/**
 * @author Philip
 */
/*
 * Copyright (C) 2017 The Android Open Source Project
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

import androidx.arch.core.executor.testing.InstantTaskExecutorRule
import androidx.room.Room
import androidx.test.core.app.ApplicationProvider
import androidx.test.ext.junit.runners.AndroidJUnit4
import org.junit.*
import org.junit.runner.RunWith
import uk.ac.aber.dcs.cascade.ui.database.AppDatabase
import uk.ac.aber.dcs.cascade.ui.database.enitity.Module

class ModuleDaoTest {

    @get:Rule
    var instantTaskExecutorRule = InstantTaskExecutorRule()

    private lateinit var database: AppDatabase

    private val module1 = Module(
        "EAM4520", "Managing Environmental Change in Practice",
        "Professor Stephen Tooth", "Semester 2", "M",
        "Geography and Earth Sciences", 20, false,
        "https://www.aber.ac.uk/en/modules/deptcurrent/Geography+and+Earth+Sciences/../EAM4520/AB0/"
    )
    private val module2 = Module(
        "CS10720", "Problems and Solutions",
        "Dr Thomas Jansen", "Semester 2", "1",
        "Computer Science", 20, false,
        "https://www.aber.ac.uk/en/modules/deptfuture/Computer+Science/../CS10720/AB0/"
    )

    @Before
    fun initDb() {
        // using an in-memory database because the information stored here disappears after test
        database = Room.inMemoryDatabaseBuilder(
            ApplicationProvider.getApplicationContext(),
            AppDatabase::class.java
        )
            // allowing main thread queries, just for testing
            .allowMainThreadQueries()
            .build()
    }

    @After
    fun closeDb() {
        database.close()
    }

    @Test
    fun getAllModuleWhenInserted() {
        database.moduleDao().insert(module1)
        val module = database.moduleDao().getAll()
        Assert.assertEquals(module[0], module1)
    }

    @Test
    fun getAllModuleByID() {
        database.moduleDao().insert(module1)
        val module = database.moduleDao().getByModuleID("EAM4520")
        Assert.assertEquals(module, module1)
    }

}