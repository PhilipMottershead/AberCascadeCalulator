package uk.ac.aber.dcs.cascade

import androidx.arch.core.executor.testing.InstantTaskExecutorRule
import androidx.room.Room
import androidx.test.core.app.ApplicationProvider
import org.junit.*
import uk.ac.aber.dcs.cascade.ui.database.AppDatabase
import uk.ac.aber.dcs.cascade.ui.database.enitity.Scheme

/**
 * @author Philip
 */
class SchemeDaoTest {
    @get:Rule
    var instantTaskExecutorRule = InstantTaskExecutorRule()

    private lateinit var database: AppDatabase

    private  val scheme1 = Scheme("N400","Accounting and Finance","BSC",
        "Aberystwyth Business School","Undergraduate",
        "Single Honours","2020/2021",3,
        "https://www.aber.ac.uk/en/study-schemes/deptfuture/Aberystwyth+Business+School/../N400-BSC/")

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
        database.schemeDao().insert(scheme1)
        val scheme = database.schemeDao().getAll()
        Assert.assertEquals(scheme[0], scheme1)
    }

    @Test
    fun getAllModuleByID() {
        database.schemeDao().insert(scheme1)
        val scheme = database.schemeDao().getBySchemeId("N400")
        Assert.assertEquals(scheme, scheme1)
    }

}