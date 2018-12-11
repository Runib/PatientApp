using PatientApp.localhost1;
using PatientApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Helper
{
    public static class ConverterDataBase
    {

        public static List<TestModel> toTestModel(Test[] tests)
        {
            WebService servObj = new WebService();
            List<TestModel> ret = new List<TestModel>(); 
            foreach (var test in tests)
            {
                TestModel testModel = new TestModel(servObj.LoadTitle(test.TitleId),test.Type,test.TestId,test.SpecimenCode,test.Priority,test.isSelected, test.OrderNumber);
                ret.Add(testModel);
            }

            return ret;
        }

        public static List<Test> toDataBase(TestModel[] tests)
        {
            WebService servObj = new WebService();
            List<Test> ret = new List<Test>();
            foreach (var test in tests)
            {
                Test t = new Test() { isSelected = test.isSelected, OrderNumber = test.OrderNumber, Priority = test.Priority, SpecimenCode = test.SpecimenCode, TestId = test.TestId, Type = test.Type,
                    TitleId =servObj.LoadTitleId(test.Title)};
                ret.Add(t);
            }

            return ret;
        }

        public static List<OrderModel> toOrderModel(Order[] orders, TestModel[] tests)
        {
            List<OrderModel> ret = new List<OrderModel>();
            foreach (var item in orders)
            {
                OrderModel ordModel = new OrderModel(item.OrderNumber, item.EndDate, item.StartDate, item.patientMRN, tests);
                ret.Add(ordModel);
            }

            return ret;
        }

        public static List<OrderModel> toOrderModel(Order[] orders)
        {
            List<OrderModel> ret = new List<OrderModel>();
            foreach (var item in orders)
            {
                OrderModel ordModel = new OrderModel(item.OrderNumber, item.EndDate, item.StartDate, item.patientMRN);
                ret.Add(ordModel);
            }

            return ret;
        }

        public static List<Order> orderModelToDataBase(OrderModel[] orders)
        {
            List<Order> ret = new List<Order>();
            foreach (var item in orders)
            {
                Order ord = new Order { EndDate = item.EndDate, OrderNumber = item.OrderNumber, patientMRN = item.patientMRN, StartDate = item.StartDate };
                ret.Add(ord); 
            }

            return ret;
        }

        public static Order orderModelToDataBase(OrderModel order)
        {
            Order ret = new Order { EndDate = order.EndDate, OrderNumber = order.OrderNumber, patientMRN = order.patientMRN, StartDate = order.StartDate };

            return ret;
        }

    }
}
