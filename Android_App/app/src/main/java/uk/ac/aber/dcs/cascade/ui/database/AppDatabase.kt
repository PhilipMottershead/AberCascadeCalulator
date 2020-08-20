package uk.ac.aber.dcs.cascade.ui.database

import android.content.Context
import androidx.room.Database
import androidx.room.Room
import androidx.room.RoomDatabase
import uk.ac.aber.dcs.cascade.ui.database.dao.ModuleDao
import uk.ac.aber.dcs.cascade.ui.database.dao.SchemeDao
import uk.ac.aber.dcs.cascade.ui.database.enitity.Module
import uk.ac.aber.dcs.cascade.ui.database.enitity.Scheme

/**
 * @author Philip
 */
@Database(entities = [Module::class,Scheme::class], version = 1)
abstract class AppDatabase : RoomDatabase() {

    abstract fun moduleDao(): ModuleDao

    abstract fun schemeDao(): SchemeDao

}