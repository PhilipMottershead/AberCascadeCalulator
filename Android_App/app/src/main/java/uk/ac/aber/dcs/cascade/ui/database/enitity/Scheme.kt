package uk.ac.aber.dcs.cascade.ui.database.enitity

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey

/**
 * @author Philip
 */
@Entity
data class Scheme(
    @PrimaryKey @ColumnInfo(name = "scheme_id") val schemeId: String,
    val title: String,
    val award: String,
    val department: String,
    @ColumnInfo(name = "undergraduate_or_postgraduate") val underOrPost: String,
    @ColumnInfo(name = "scheme_type") val schemeType: String,
    val year: String,
    val duration: Int,
    val url: String
)