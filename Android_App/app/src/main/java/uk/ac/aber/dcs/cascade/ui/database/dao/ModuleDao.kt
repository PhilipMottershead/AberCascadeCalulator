package uk.ac.aber.dcs.cascade.ui.database.dao

import androidx.room.Dao
import androidx.room.Insert
import androidx.room.OnConflictStrategy
import androidx.room.Query
import uk.ac.aber.dcs.cascade.ui.database.enitity.Module


/**
 * @author Philip
 */
@Dao
interface ModuleDao {

    @Query("SELECT * FROM module")
    fun getAll(): List<Module>

    @Insert(onConflict = OnConflictStrategy.IGNORE)
    fun insert(word: Module)

    @Query("SELECT * FROM module WHERE module_id = :id")
    fun getByModuleID(id:String) : Module


}