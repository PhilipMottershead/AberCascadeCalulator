package uk.ac.aber.dcs.cascade.ui.database

import uk.ac.aber.dcs.cascade.ui.database.enitity.Module

/**
 * @author Philip
 */
interface DatabaseHelper {

    suspend fun getModules(): List<Module>

}