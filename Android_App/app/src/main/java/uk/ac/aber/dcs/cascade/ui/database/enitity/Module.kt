package uk.ac.aber.dcs.cascade.ui.database.enitity

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey
import org.jetbrains.annotations.NotNull

/**
 * @author Philip
 */
@Entity
data class Module(
    @PrimaryKey @ColumnInfo(name = "module_id")val moduleId: String,
    val title: String,
    val coordinator: String,
    val semester: String,
    val year: String,
    val department: String,
    val credits: Int,
    val welsh: Boolean,
    val url: String
)
