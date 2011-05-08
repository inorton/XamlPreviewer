
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG_X86
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG"
ASSEMBLY = bin/Debug/XamlPreviewer.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = winexe
PROJECT_REFERENCES =  \
	../Views/bin/Debug/Views.dll \
	../ViewModels/bin/Debug/ViewModels.dll
BUILD_DIR = bin/Debug

XAMLPREVIEWER_EXE_MDB_SOURCE=bin/Debug/XamlPreviewer.exe.mdb
XAMLPREVIEWER_EXE_MDB=$(BUILD_DIR)/XamlPreviewer.exe.mdb
START_XAML_SOURCE=start.xaml
VIEWS_DLL_SOURCE=../Views/bin/Debug/Views.dll
VIEWS_DLL_MDB_SOURCE=../Views/bin/Debug/Views.dll.mdb
VIEWMODELS_DLL_SOURCE=../ViewModels/bin/Debug/ViewModels.dll
VIEWMODELS_DLL_MDB_SOURCE=../ViewModels/bin/Debug/ViewModels.dll.mdb

endif

if ENABLE_RELEASE_X86
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Release/XamlPreviewer.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = winexe
PROJECT_REFERENCES =  \
	../Views/bin/Release/Views.dll \
	../ViewModels/bin/Release/ViewModels.dll
BUILD_DIR = bin/Release

XAMLPREVIEWER_EXE_MDB=
START_XAML_SOURCE=start.xaml
VIEWS_DLL_SOURCE=../Views/bin/Debug/Views.dll
VIEWS_DLL_MDB_SOURCE=../Views/bin/Debug/Views.dll.mdb
VIEWMODELS_DLL_SOURCE=../ViewModels/bin/Debug/ViewModels.dll
VIEWMODELS_DLL_MDB_SOURCE=../ViewModels/bin/Debug/ViewModels.dll.mdb

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(XAMLPREVIEWER_EXE_MDB) \
	$(START_XAML) \
	$(VIEWS_DLL) \
	$(VIEWS_DLL_MDB) \
	$(VIEWMODELS_DLL) \
	$(VIEWMODELS_DLL_MDB)  

BINARIES = \
	$(XAMLPREVIEWER)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES) 

FILES =  \
	AssemblyInfo.cs \
	gtk-gui/generated.cs \
	gtk-gui/MainWindow.cs \
	Main.cs \
	MainWindow.cs 

DATA_FILES = 

RESOURCES = gtk-gui/gui.stetic 

EXTRAS = \
	start.xaml \
	xamlpreviewer.in 

REFERENCES =  \
	../ViewModels/bin/Debug/ViewModels.dll \
	../Views/bin/Debug/Views.dll \
	Mono.Posix \
	-pkg:glade-sharp-2.0 \
	-pkg:glib-sharp-2.0 \
	-pkg:gtk-sharp-2.0 \
	-pkg:gtksourceview2-sharp \
	-pkg:mono.moondesk.commands \
	-pkg:mono.moondesk.moonwindow \
	-pkg:mono.moondesk.viewloader \
	-pkg:moonlight-desktop-4.0 \
	-pkg:moonlight-gtk-4.0 \
	System

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

include $(top_srcdir)/Makefile.include

START_XAML = $(BUILD_DIR)/start.xaml
VIEWS_DLL = $(BUILD_DIR)/Views.dll
VIEWS_DLL_MDB = $(BUILD_DIR)/Views.dll.mdb
VIEWMODELS_DLL = $(BUILD_DIR)/ViewModels.dll
VIEWMODELS_DLL_MDB = $(BUILD_DIR)/ViewModels.dll.mdb
XAMLPREVIEWER = $(BUILD_DIR)/xamlpreviewer

$(eval $(call emit-deploy-target,START_XAML))
$(eval $(call emit-deploy-target,VIEWS_DLL))
$(eval $(call emit-deploy-target,VIEWS_DLL_MDB))
$(eval $(call emit-deploy-target,VIEWMODELS_DLL))
$(eval $(call emit-deploy-target,VIEWMODELS_DLL_MDB))
$(eval $(call emit-deploy-wrapper,XAMLPREVIEWER,xamlpreviewer,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
