Imports System
Imports EnvDTE
Imports EnvDTE80
Imports EnvDTE90
Imports System.Diagnostics

Public Module SolutionCollapser

    Sub CollapseAll()
        ' Activate the Solution Explorer
        DTE.Windows.Item(Constants.vsWindowKindSolutionExplorer).Activate()

        ' Get the solution node
        Dim ui As UIHierarchy = DTE.ActiveWindow.Object
        Dim sln As UIHierarchyItem = ui.UIHierarchyItems.Item(1)

        ' Collapse each item under the solution node
        Dim item As UIHierarchyItem
        For Each item In sln.UIHierarchyItems
            CollapseItems(item)
        Next

    End Sub

    Sub CollapseItems(ByVal item As UIHierarchyItem)
        Dim subItem As UIHierarchyItem
        For Each subItem In item.UIHierarchyItems
            CollapseItems(subItem)
        Next
        item.UIHierarchyItems.Expanded = False
    End Sub

End Module
