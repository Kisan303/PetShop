﻿// <auto-generated />
namespace PetShop.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
    public sealed partial class AddOwnerIdToPet : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddOwnerIdToPet));
        
        string IMigrationMetadata.Id
        {
            get { return "202409190021591_AddOwnerIdToPet"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}