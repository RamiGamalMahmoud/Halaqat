using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Halaqat.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedSorahas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"
INSERT INTO Sorahs (Name) VALUES ('الفاتحة');
INSERT INTO Sorahs (Name) VALUES ('البقرة');
INSERT INTO Sorahs (Name) VALUES ('آل عمران');
INSERT INTO Sorahs (Name) VALUES ('النساء');
INSERT INTO Sorahs (Name) VALUES ('المائدة');
INSERT INTO Sorahs (Name) VALUES ('الأنعام');
INSERT INTO Sorahs (Name) VALUES ('الأعراف');
INSERT INTO Sorahs (Name) VALUES ('الأنفال');
INSERT INTO Sorahs (Name) VALUES ('التوبة');
INSERT INTO Sorahs (Name) VALUES ( 'يونس');
INSERT INTO Sorahs (Name) VALUES ( 'هود');
INSERT INTO Sorahs (Name) VALUES ( 'يوسف');
INSERT INTO Sorahs (Name) VALUES ( 'الرعد');
INSERT INTO Sorahs (Name) VALUES ( 'إبراهيم');
INSERT INTO Sorahs (Name) VALUES ( 'الحجر');
INSERT INTO Sorahs (Name) VALUES ( 'النحل');
INSERT INTO Sorahs (Name) VALUES ( 'الإسراء');
INSERT INTO Sorahs (Name) VALUES ( 'الكهف');
INSERT INTO Sorahs (Name) VALUES ( 'مريم');
INSERT INTO Sorahs (Name) VALUES ( 'طه');
INSERT INTO Sorahs (Name) VALUES ( 'الأنبياء');
INSERT INTO Sorahs (Name) VALUES ( 'الحج');
INSERT INTO Sorahs (Name) VALUES ( 'المؤمنون');
INSERT INTO Sorahs (Name) VALUES ( 'النور');
INSERT INTO Sorahs (Name) VALUES ( 'الفرقان');
INSERT INTO Sorahs (Name) VALUES ( 'الشعراء');
INSERT INTO Sorahs (Name) VALUES ( 'النمل');
INSERT INTO Sorahs (Name) VALUES ( 'القصص');
INSERT INTO Sorahs (Name) VALUES ( 'العنكبوت');
INSERT INTO Sorahs (Name) VALUES ( 'الروم');
INSERT INTO Sorahs (Name) VALUES ( 'لقمان');
INSERT INTO Sorahs (Name) VALUES ( 'السجدة');
INSERT INTO Sorahs (Name) VALUES ( 'الأحزاب');
INSERT INTO Sorahs (Name) VALUES ( 'سبأ');
INSERT INTO Sorahs (Name) VALUES ( 'فاطر');
INSERT INTO Sorahs (Name) VALUES ( 'يس');
INSERT INTO Sorahs (Name) VALUES ( 'الصافات');
INSERT INTO Sorahs (Name) VALUES ( 'ص');
INSERT INTO Sorahs (Name) VALUES ( 'الزمر');
INSERT INTO Sorahs (Name) VALUES ( 'غافر');
INSERT INTO Sorahs (Name) VALUES ( 'فصلت');
INSERT INTO Sorahs (Name) VALUES ( 'الشورى');
INSERT INTO Sorahs (Name) VALUES ( 'الزخرف');
INSERT INTO Sorahs (Name) VALUES ( 'الدخان');
INSERT INTO Sorahs (Name) VALUES ( 'الجاثية');
INSERT INTO Sorahs (Name) VALUES ( 'الأحقاف');
INSERT INTO Sorahs (Name) VALUES ( 'محمد');
INSERT INTO Sorahs (Name) VALUES ( 'الفتح');
INSERT INTO Sorahs (Name) VALUES ( 'الحجرات');
INSERT INTO Sorahs (Name) VALUES ( 'ق');
INSERT INTO Sorahs (Name) VALUES ( 'الذاريات');
INSERT INTO Sorahs (Name) VALUES ( 'الطور');
INSERT INTO Sorahs (Name) VALUES ( 'النجم');
INSERT INTO Sorahs (Name) VALUES ( 'القمر');
INSERT INTO Sorahs (Name) VALUES ( 'الرحمن');
INSERT INTO Sorahs (Name) VALUES ( 'الواقعة');
INSERT INTO Sorahs (Name) VALUES ( 'الحديد');
INSERT INTO Sorahs (Name) VALUES ( 'المجادلة');
INSERT INTO Sorahs (Name) VALUES ( 'الحشر');
INSERT INTO Sorahs (Name) VALUES ( 'الممتحنة');
INSERT INTO Sorahs (Name) VALUES ( 'الصف');
INSERT INTO Sorahs (Name) VALUES ( 'الجمعة');
INSERT INTO Sorahs (Name) VALUES ( 'المنافقون');
INSERT INTO Sorahs (Name) VALUES ( 'التغابن');
INSERT INTO Sorahs (Name) VALUES ( 'الطلاق');
INSERT INTO Sorahs (Name) VALUES ( 'التحريم');
INSERT INTO Sorahs (Name) VALUES ( 'الملك');
INSERT INTO Sorahs (Name) VALUES ( 'القلم');
INSERT INTO Sorahs (Name) VALUES ( 'الحاقة');
INSERT INTO Sorahs (Name) VALUES ( 'المعارج');
INSERT INTO Sorahs (Name) VALUES ( 'نوح');
INSERT INTO Sorahs (Name) VALUES ( 'الجن');
INSERT INTO Sorahs (Name) VALUES ( 'المزمل');
INSERT INTO Sorahs (Name) VALUES ( 'المدثر');
INSERT INTO Sorahs (Name) VALUES ( 'القيامة');
INSERT INTO Sorahs (Name) VALUES ( 'الإنسان');
INSERT INTO Sorahs (Name) VALUES ( 'المرسلات');
INSERT INTO Sorahs (Name) VALUES ( 'النبأ');
INSERT INTO Sorahs (Name) VALUES ( 'النازعات');
INSERT INTO Sorahs (Name) VALUES ( 'عبس');
INSERT INTO Sorahs (Name) VALUES ( 'التكوير');
INSERT INTO Sorahs (Name) VALUES ( 'الانفطار');
INSERT INTO Sorahs (Name) VALUES ( 'المطففين');
INSERT INTO Sorahs (Name) VALUES ( 'الانشقاق');
INSERT INTO Sorahs (Name) VALUES ( 'البروج');
INSERT INTO Sorahs (Name) VALUES ( 'الطارق');
INSERT INTO Sorahs (Name) VALUES ( 'الأعلى');
INSERT INTO Sorahs (Name) VALUES ( 'الغاشية');
INSERT INTO Sorahs (Name) VALUES ( 'الفجر');
INSERT INTO Sorahs (Name) VALUES ( 'البلد');
INSERT INTO Sorahs (Name) VALUES ( 'الشمس');
INSERT INTO Sorahs (Name) VALUES ( 'الليل');
INSERT INTO Sorahs (Name) VALUES ( 'الضحى');
INSERT INTO Sorahs (Name) VALUES ( 'الشرح');
INSERT INTO Sorahs (Name) VALUES ( 'التين');
INSERT INTO Sorahs (Name) VALUES ( 'العلق');
INSERT INTO Sorahs (Name) VALUES ( 'القدر');
INSERT INTO Sorahs (Name) VALUES ( 'البينة');
INSERT INTO Sorahs (Name) VALUES ( 'الزلزلة');
INSERT INTO Sorahs (Name) VALUES ( 'العاديات');
INSERT INTO Sorahs (Name) VALUES ( 'القارعة');
INSERT INTO Sorahs (Name) VALUES ( 'التكاثر');
INSERT INTO Sorahs (Name) VALUES ( 'العصر');
INSERT INTO Sorahs (Name) VALUES ( 'الهمزة');
INSERT INTO Sorahs (Name) VALUES ( 'الفيل');
INSERT INTO Sorahs (Name) VALUES ( 'قريش');
INSERT INTO Sorahs (Name) VALUES ( 'الماعون');
INSERT INTO Sorahs (Name) VALUES ( 'الكوثر');
INSERT INTO Sorahs (Name) VALUES ( 'الكافرون');
INSERT INTO Sorahs (Name) VALUES ( 'النصر');
INSERT INTO Sorahs (Name) VALUES ( 'المسد');
INSERT INTO Sorahs (Name) VALUES ( 'الإخلاص');
INSERT INTO Sorahs (Name) VALUES ( 'الفلق');
INSERT INTO Sorahs (Name) VALUES ( 'الناس');


";
            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
