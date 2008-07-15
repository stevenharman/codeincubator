using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FakeContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FakeContextTest
{
    [TestClass]
    public class When_given_a_fake_table_with_values : Specification
    {
        private IList<Entity> _entities;
        private TableFake<Entity> _table;
        private Entity _firstEntity;
        private Entity _secondEntity;
        private Entity _thirdEntity;

        protected override void Before_each_spec()
        {
            base.Before_each_spec();

            _firstEntity = new Entity {Id = 1, Name = "One"};
            _secondEntity = new Entity { Id = 2, Name = "Two" };
            _thirdEntity = new Entity { Id = 3, Name = "Three" };

            _entities = new List<Entity>
                            {
                                _firstEntity,
                                _secondEntity,
                                _thirdEntity
                            };

            _table = new TableFake<Entity>(_entities);
        }

        [TestMethod]
        public void Then_InsertOnSubmit_should_add_new_entity()
        {
            var entity = new Entity {Id = 5, Name = "Five"};
            _table.InsertOnSubmit(entity);

            _table.ShouldContain(entity);
        }

        [TestMethod]
        public void Then_InsertOnSubmit_should_add_new_object()
        {
            object entity = new Entity { Id = 5, Name = "Five" };
            _table.InsertOnSubmit(entity);

            _table.ShouldContain(entity);
        }

        [TestMethod]
        public void Then_InsertAllOnSubmit_should_add_new_entities()
        {
            var entity = new Entity { Id = 5, Name = "Five" };
            var secondEntity = new Entity {Id = 6, Name = "six" };
            _table.InsertAllOnSubmit(new [] {entity, secondEntity});

            _table.ShouldContain(entity);
            _table.ShouldContain(secondEntity);
        }

        [TestMethod]
        public void Then_InsertAllOnSubmit_should_add_new_objects()
        {
            object entity = new Entity { Id = 5, Name = "Five" };
            object secondEntity = new Entity { Id = 6, Name = "six" };
            _table.InsertAllOnSubmit((IEnumerable)new[] { entity, secondEntity });

            _table.ShouldContain(entity);
            _table.ShouldContain(secondEntity);
        }

        [TestMethod]
        public void Then_AttachAll_should_add_new_entities()
        {
            var entity = new Entity { Id = 5, Name = "Five" };
            var secondEntity = new Entity { Id = 6, Name = "six" };
            _table.AttachAll(new[] { entity, secondEntity });

            _table.ShouldContain(entity);
            _table.ShouldContain(secondEntity);
        }

        [TestMethod]
        public void Then_AttachAll_with_modified_should_add_new_entities()
        {
            var entity = new Entity { Id = 5, Name = "Five" };
            var secondEntity = new Entity { Id = 6, Name = "six" };
            _table.AttachAll(new[] { entity, secondEntity }, true);

            _table.ShouldContain(entity);
            _table.ShouldContain(secondEntity);
        }

        [TestMethod]
        public void Then_AttachAll_object_should_add_new_entities()
        {
            object entity = new Entity { Id = 5, Name = "Five" };
            object secondEntity = new Entity { Id = 6, Name = "six" };
            _table.AttachAll((IEnumerable) new [] { entity, secondEntity });

            _table.ShouldContain(entity);
            _table.ShouldContain(secondEntity);
        }

        [TestMethod]
        public void Then_AttachAll_objects_with_modified_should_add_new_entities()
        {
            object entity = new Entity { Id = 5, Name = "Five" };
            object secondEntity = new Entity { Id = 6, Name = "six" };
            _table.AttachAll((IEnumerable) new[] { entity, secondEntity }, true);

            _table.ShouldContain(entity);
            _table.ShouldContain(secondEntity);
        }

        [TestMethod]
        public void Then_Attach_should_add_new_entity()
        {
            var entity = new Entity { Id = 5, Name = "Five" };
            _table.Attach(entity);

            _table.ShouldContain(entity);
        }

        [TestMethod]
        public void Then_Attach_with_modified_should_add_new_entity()
        {
            var entity = new Entity { Id = 5, Name = "Five" };
            _table.Attach(entity, true);

            _table.ShouldContain(entity);
        }

        [TestMethod]
        public void Then_Attach_with_an_original_should_add_new_entity()
        {
            var entity = new Entity { Id = 5, Name = "Five" };
            _table.Attach(entity, null);

            _table.ShouldContain(entity);
        }

        [TestMethod]
        public void Then_Attach_should_add_new_object()
        {
            object entity = new Entity { Id = 5, Name = "Five" };
            _table.Attach(entity);

            _table.ShouldContain(entity);
        }

        [TestMethod]
        public void Then_Attach_with_modified_should_add_new_object()
        {
            object entity = new Entity { Id = 5, Name = "Five" };
            _table.Attach(entity, true);

            _table.ShouldContain(entity);
        }

        [TestMethod]
        public void Then_Attach_with_an_original_should_add_new_object()
        {
            object entity = new Entity { Id = 5, Name = "Five" };
            _table.Attach(entity, null);

            _table.ShouldContain(entity);
        }

        [TestMethod]
        public void Then_DeleteOnSubmit_should_remove_the_entity()
        {
            _table.DeleteOnSubmit(_firstEntity);

            _table.ShouldNotContain(_firstEntity);
        }

        [TestMethod]
        public void Then_DeleteOnSubmit_should_remove_the_object()
        {
            _table.DeleteOnSubmit((object) _firstEntity);

            _table.ShouldNotContain(_firstEntity);
        }

        [TestMethod]
        public void Then_DeleteAllOnSubmit_should_remove_the_entities()
        {
            _table.DeleteAllOnSubmit(new[] {_firstEntity, _secondEntity});

            _table.ShouldNotContain(_firstEntity);
            _table.ShouldNotContain(_secondEntity);
        }

        [TestMethod]
        public void Then_DeleteAllOnSubmit_should_remove_the_objects()
        {
            _table.DeleteAllOnSubmit((IEnumerable) new object[] { _firstEntity, _secondEntity });

            _table.ShouldNotContain(_firstEntity);
            _table.ShouldNotContain(_secondEntity);
        }

        [TestMethod]
        public void Then_GetOriginalEntityState_should_just_return_the_same_entity()
        {
            _table.GetOriginalEntityState(_firstEntity).ShouldBeTheSameAs(_firstEntity);
        }

        [TestMethod]
        public void Then_GetOriginalEntityState_should_just_return_the_same_object()
        {
            _table.GetOriginalEntityState((object) _firstEntity).ShouldBeTheSameAs(_firstEntity);
        }

        [TestMethod]
        public void Then_where_should_find_the_correct_item()
        {
            var result = _table.Where(e => e.Id == 2);

            result.Single().Name.ShouldBe("Two");
        }

        [TestMethod]
        public void Then_Context_should_return_null()
        {
            _table.Context.ShouldBeNull();
        }

        [TestMethod]
        public void Then_IsReadOnly_should_be_false()
        {
            _table.IsReadOnly.ShouldBeFalse();
        }

        [TestMethod]
        public void Then_GetList_should_be_the_same_as_the_original_list()
        {
            var entities = _table.GetList();
            entities.ShouldContain(_firstEntity);
            entities.ShouldContain(_secondEntity);
            entities.ShouldContain(_thirdEntity);
            entities.Count.ShouldBe(3);
        }

        [TestMethod]
        public void Then_ContainsListCollection_should_be_true()
        {
            _table.ContainsListCollection.ShouldBeTrue();
        }

        [TestMethod]
        public void Then_GetModifiedMembers_should_return_an_empty_array()
        {
            _table.GetModifiedMembers(_firstEntity).Count().ShouldBe(0);
        }

        [TestMethod]
        public void Then_GetModifiedMembers_on_an_object_should_return_an_empty_array()
        {
            _table.GetModifiedMembers((object) _firstEntity).Count().ShouldBe(0);
        }

        [TestMethod]
        public void Then_GetNewBindingList_should_return_a_list_with_the_original_entities()
        {
            var list = _table.GetNewBindingList();
            list.ShouldContain(_firstEntity);
            list.ShouldContain(_secondEntity);
            list.ShouldContain(_thirdEntity);
            list.Count.ShouldBe(3);
        }

        private class Entity
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
