package uk.ac.aber.dcs.cascade

import android.graphics.Typeface.createFromAsset
import androidx.arch.core.executor.testing.InstantTaskExecutorRule
import androidx.room.Room
import androidx.test.core.app.ApplicationProvider
import androidx.test.platform.app.InstrumentationRegistry
import org.junit.*
import uk.ac.aber.dcs.cascade.ui.database.AppDatabase

/**
 * @author Philip
 */
class DatabaseTestNonInMemory {
    @get:Rule
    var instantTaskExecutorRule = InstantTaskExecutorRule()

    private lateinit var database: AppDatabase
    @Before
    fun initDb() {
        // using an in-memory database because the information stored here disappears after test
        val appContext = InstrumentationRegistry.getInstrumentation().targetContext

        database =
            Room.databaseBuilder(appContext.applicationContext,
        AppDatabase::class.java,
        "mindorks-example-coroutines")
        .createFromAsset("database/cascade.db")
            .build()
    }

    @After
    fun closeDb() {
        database.close()
    }

    @Test
    fun getAllModuleWhenInserted() {
        val module = database.moduleDao().getAll()
        Assert.assertEquals(module[0], module)
    }
}