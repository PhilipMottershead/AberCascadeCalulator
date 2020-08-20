package uk.ac.aber.dcs.cascade.ui.database

import uk.ac.aber.dcs.cascade.ui.database.enitity.Module

/**
 * @author Philip
 */
class DatabaseHelperImpl(private val appDatabase: AppDatabase) : DatabaseHelper {

    override suspend fun getModules(): List<Module> = appDatabase.moduleDao().getAll()
}