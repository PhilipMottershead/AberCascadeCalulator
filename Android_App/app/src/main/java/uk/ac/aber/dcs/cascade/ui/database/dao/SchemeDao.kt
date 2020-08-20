package uk.ac.aber.dcs.cascade.ui.database.dao

import androidx.room.Dao
import androidx.room.Insert
import androidx.room.OnConflictStrategy
import androidx.room.Query
import uk.ac.aber.dcs.cascade.ui.database.enitity.Module
import uk.ac.aber.dcs.cascade.ui.database.enitity.Scheme

/**
 * @author Philip
 */
@Dao
interface SchemeDao {

    @Query("SELECT * FROM scheme")
    fun getAll(): List<Scheme>

    @Insert(onConflict = OnConflictStrategy.IGNORE)
    fun insert(word: Scheme)

    @Query("SELECT * FROM scheme WHERE scheme_id = :id")
    fun getBySchemeId(id:String) : Scheme

}