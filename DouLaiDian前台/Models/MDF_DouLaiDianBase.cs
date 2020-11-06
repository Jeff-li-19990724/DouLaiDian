using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using QT;
using HT;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace DouLaiDian.Models
{
    public class MDF_DouLaiDian : DbContext
    {
        /// <summary>
        /// 数据库连接核心类（数据库上下文类）
        /// </summary>
        public MDF_DouLaiDian()
            : base("name=MDF_DouLaiDian")   //数据库上下文实体——和数据库名字相同
        {

        }
        public DbSet<FoodList> FoodList { get; set; }
        public DbSet<FoodType> FoodType { get; set; }
        public DbSet<Foodinfo> Foodinfo { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderList> OrderList { get; set; }
        public DbSet<FoodTable> FoodTable { get; set; }
    }
}
namespace QT
{
    public class FoodList
    {
        //主键但是不自增——食品编号
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int FoodID { get; set; }
        //食品名称

        public string FoodName { get; set; }

        //单价
        public double Price { set; get; }

        //分类
        public int FoodTypeID { set; get; }
        //图片
        public string imageUrl { get; set; }
        //详细信息
        public string introduce { get; set; }
        public FoodType FoodType { get; set; }
    }
    public class FoodType
    {
        [Key]
        [DisplayName("食品种类ID")]
        public int FoodTypeID { set; get; }
        [DisplayName("食品种类名称")]
        public string FoodTypeName { set; get; }
        [DisplayName("食品种类描述")]
        public string describe { set; get; }
        [DisplayName("食品种类外键连接")]
        public List<FoodList> FoodList { get; set; }
    }
    public class Foodinfo
    {
        [Key]
        public int foodinfoID { set; get; }
        public int FoodID { get; set; }
        public FoodList FoodList { get; set; }
        [DisplayName("食材")]
        public string Ingredients { get; set; }
        [DisplayName("菜品描述")]
        public string Infodescribe { set; get; }
    }
    /// <summary>
    /// 点餐
    /// </summary>
    public class Order
    {
        //订单编号
        [Key]
        [DisplayName("订单编号")]
        public int OrderID { get; set; }
        //消费者手机号
       [DisplayName("消费者手机号")] 
        public string phone { get; set; }
        //总价格
        [DisplayName("总价格")]
        public double TotalParse { get; set; }
        //消费日期——下单时间
        [DisplayName("下单日期")]
        public DateTime Date { get; set; }
        //结算与否
        [DisplayName("状态")]
        public bool ISOut { get; set; }
    }
    public class OrderList
    {
        [Key]
        public int OrID { set; get; }
        //归属订单的编号
        public int OrderID { get; set; }
        //创建外键
        public Order order { get; set; }
        //食品名称
        public string foodname { get; set; }
        public double price { set; get; }
        public int num { get; set; }
    }
}
namespace HT
{
    public class FoodTable
    {
        [Key]
        [DisplayName("餐桌编号")]
        public int TableID { get; set; }
        [DisplayName("餐桌名称")]
        public string TableName { get; set; }
        [DisplayName("餐桌状态")]
        public string TableState { get; set; }
        [DisplayName("预定时间")]
        //使用时间
        public  DateTime DateOut { get; set; }
    }
}
