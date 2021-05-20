using System.Collections.Generic;
using System.Data;
using cs_knights_tale.Models;
using Dapper;

namespace cs_knights_tale.Repositories
{
    public class LordsRepository : IRepository<Lord>
    {
        private readonly IDbConnection _db;

        public LordsRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Lord> GetAll()
        {
            string sql = "SELECT * FROM lords";
            return _db.Query<Lord>(sql);
        }

        public Lord GetById(int id)
        {
            // Dapper uses '@' to indicate a variable that can be safelt injected in the Query arguments
            string sql = "SELECT * FROM lords WHERE id = @id";
            // Query first or default returns a single item or 'null'
            return _db.QueryFirstOrDefault<Lord>(sql, new { id });
        }

        public Lord Create(Lord newLord)
        {
            string sql = @"
            INSERT INTO lords
            (name, age, imgUrl)
            VALUES
            (@Name, @Age, @ImgUrl)
            SELECT LAST_INSERT_ID()
            ";
            newLord.Id = _db.ExecuteScalar<int>(sql, newLord);
            return newLord;
        }

        public bool Update(Lord original)
        {
            string sql = @"
            UPDATE lords
            SET
                name = @Name,
                age = @Age,
                imgUrl = @ImgUrl
            ";
            int affectedRows = _db.Execute(sql, original);
            return affectedRows == 1;
        }

        public bool Delete(int id)
        {
            string sql = "DELETE FROM lords WHERE id = @id LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id });
            return affectedRows == 1;
        }

    }
}