using System.Collections.Generic;
using NHibernate;
using NHibernate.Metadata;
using NUnit.Framework;
using FinalProject.Data.NHibernateMaps;
using SharpArch.Data.NHibernate;
using SharpArch.Testing.NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.IO;
using FluentNHibernate;
using System.Reflection;
using System;
using NHibernate.Mapping;
using FluentNHibernate.Automapping;

namespace SanityChecks.NHibernateMaps
{
    /// <summary>
    /// Provides a means to verify that the target database is in compliance with all mappings.
    /// Taken from http://ayende.com/Blog/archive/2006/08/09/NHibernateMappingCreatingSanityChecks.aspx.
    /// 
    /// If this is failing, the error will likely inform you that there is a missing table or column
    /// which needs to be added to your database.
    /// </summary>
    [TestFixture]
    [Category("DB Tests")]
    public class MappingIntegrationTests
    {
        protected Configuration configuration;
        AutoPersistenceModel model;


        [SetUp]
        public virtual void SetUp()
        {
            string[] mappingAssemblies = RepositoryTestsHelper.GetMappingAssemblies();
            model = new AutoPersistenceModelGenerator().Generate();
            configuration = NHibernateSession.Init(new SimpleSessionStorage(), mappingAssemblies,
                                   model,
                                   "../../../../app/Website/config/NHibernate.config");
            ServiceLocatorInitializer.Init();
        }

        [TearDown]
        public virtual void TearDown()
        {
            NHibernateSession.CloseAllSessions();
            NHibernateSession.Reset();
        }

        [Test]
        public void CanConfirmDatabaseMatchesMappings()
        {
            var allClassMetadata = NHibernateSession.GetDefaultSessionFactory().GetAllClassMetadata();

            foreach (var entry in allClassMetadata)
            {
                NHibernateSession.Current.CreateCriteria(entry.Value.GetMappedClass(EntityMode.Poco))
                     .SetMaxResults(0).List();
            }
        }

        /// <summary>
        /// Generates and outputs the database schema SQL to the console
        /// </summary>
        [Test]
        public void CanGenerateMappingFiles()
        {
            model.WriteMappingsTo(@"W:\Sample\mappings\");
        }

        /// <summary>
        /// Generates and outputs the database schema SQL to the console
        /// </summary>
        [Test]
        public void CanGenerateDatabaseSchema()
        {
            var session = NHibernateSession.GetDefaultSessionFactory().OpenSession();

            using (TextWriter stringWriter = new StreamWriter(@"W:\Sample\UnitTestGeneratedSchema.sql"))
            {
                new SchemaExport(configuration).Execute(true, false, false, session.Connection, stringWriter);
            }
        }
    }
}
