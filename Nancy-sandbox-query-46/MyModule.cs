namespace Nancy_sandbox_query_46
{
    using System;

    using Nancy;

    public class MyModule : NancyModule
    {
        public MyModule()
        {
//            Get["/path/{Name}/action"] = parameters =>
//                {
//                    return MyMethod(parameters.Name, methodToBeCalled); // this does not compile              
//                };

            Get["/path/{Name}/anotherAction"] = parameters =>
                {
                    return MyMethod(parameters.Name as string, anotherMethodToBeCalled);
                };
        }

        public Response MyMethod(string name, Func<int> doSomething)
        {
            doSomething();
            return Response.AsText(string.Format("Hello {0}", name));
        }

        public int methodToBeCalled()
        {
            return -1;
        }

        public int anotherMethodToBeCalled()
        {
            return 1;
        }
    }
}
