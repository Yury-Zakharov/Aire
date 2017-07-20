# Loop Service
## Aire homework

## Engineering
### Prerequisites
This solution was developed using Microsoft Visual Studio 2017 
To be able to build the solution and run unit tests you will need to install [MS Visual Studio 2017](https://www.visualstudio.com/downloads/, "Download VS").
Community Edition is free of charge and will suffice for the purpouse.

Visual Studio Installer offers multiple options to include into current installation, please choose _.NET desktop development_ workload.
Please ensure that _Windows Communication Foundation_ and _SQL Server Express LocalDB_ are selected in _Individual components_ tab.
The homework solution uses SQL server LocalDB database. This database will be created automatically on first access. This may cause a slight delay when the service accesses the database for the first time.
Database consists of two files in your local directory %systemdrive%\users\username :
* Aire.Data.LoopData.mdf
* Aire.Data.LoopData_log.ldf
* 
You can delete this database after you finish torchuring the service.

### Architecture
This service is implemented as a modular solution and consists of several projects:
* Aire.Data is data access module (data storage can be replaced by implementing another data access module)
* Aire.Domain contains types and interfaces common for the solution
* Aire.Host contains tools for starting and stopping the service
* Aire.IoC is responsible for dependencies injection
* Aire.Services contains service implementation
* Aire.Governor contains pluggable components responsible for data analysis. Each component implements a model for a single event.


### How to run the service
Simply build the solution and run the _Aire.Host_ project.
By default the service will listen at http://localhost:2359/ , this can be changed in the App.config configuration file or Aire.Host.exe.config file if you are running the
service outside Visual Studio.
Depending on the security policy running  the service may cause security exceptions. This can be solved by running the service with elevated privileges (_not recommended_) 
or adding the port number to discretionary access control list:
> netsh http add urlacl url=http://*:2358/ user=domain\username

The service implemented as a self-hosted service and can be used as stand-alone executable or installed as Windows service. To install the service as Windows service
run 
> Aire.Host.exe install
> 
and follow the instructions.
Feeding the homework service is easy - just call the /apps endpoint passing the array of applications in a request body.
As there is a limit for the request size, pass the data in small portions (6000-7000 records at a time).

### Tests
Unit tests are reflecting my understanding of a models for the events chosen. Each unit test generates test data set and runs the model ageinst this set.

Unit tests can be run by Visual Studio.

## Integration tests
The project Aire.Integration.Test is an integration test for the homework solution.
This test is not fully automated, you need to have the main service running and manually start the test.
It performs only connectivity check at the moment but ideally should be a part of automated deployment process.

### Limitations
Since the service is mere proof of concept it has a lot of limitations:
* No data validation
* Performance issues not addressed
* Security issues not addressed
* Data structures need to be tuned
* You will definitely find more issues...

I beleive these are acceptable at this stage because the main purpose of the service is to approve or disapprove the approach to the problem. 
### Ways to improve 

As the service will mature, I will need to revisit these limitations. Reasons are:
* Clean data allows better baseline for analysis, better results.
* Performance becomes critical with bigger volumes of data. Ways to improve are, for example in-memory data storage, partitioning, faster algorithms...
* Security requirements may come up when the service is integrated with third party systems or exposed to external systems.
* The interface of the service now looks a bit artificial, I would suggest pushing or streaming events to the consumer in real time. Latency is under the question since the overall architecture of a system is unknown.
* Models are the core of this service and should be improved starting from the early stages. When the system is more or less mature I would think about implementing a DSL that allows to describe the models in human language (well, a subset of language, simplified and formal).


## Data science
### Events
I have chosen two events:
* EXAGGERATED_INCOME as I consider this as a possible fraud and should have higher priority.
* NEW_GEO - in my opinion this allows business to respond to the changes on a global market.

### Assumptions
I understand that my approach to the analysis is quite naive and my models are not elaborated well, but nevertheless, I will improvce gradually :)
* EXAGGERATED_INCOME. I suppose that people of the same occupation and comparable work experience, living in the same area should have comparable income.
Extracting Occupation attribute from the application is complicated task since this data is not structured, so I have not included the occupation into the model.
The granularity of geographic attribute is State, if we need smaller grain, we can use Zip-code with roughening - less precise code gives bigger spot on a map.
I grouped applications by State and employment length. For each group the average income is calculated. (I suspect that this is criteria is farfrom being correct, need time for research).
The trigger is the income that exceeds the average by  certain  percent.
My testing reveals that averaging does not work as I assumed. May be the percentile value would perform better.
* NEW_GEO. If there were two separate data sets I would simply check whether the value of geographic attribute is present in a base line.
Having all data in a single set I grouped application by the State and picked application with minimal issue date in each group.

### Ways to improve
* Learn more from experts and practitioners.
* Practice more.

What I mean is building models is iterative and non-linear process and at this stage I only can see that my models are not working well. To understand what exactly is wrong, I need to follow those two paragraphs.



