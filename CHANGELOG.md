#CHANGELOG

## [1.0.0] - 2024-11-27

### Added

* Buttons

* Tabs

## [1.1.0] - 2024-12-3

### Added
* Tabs now destroy themselves if all the buttons underneath them are destroyed.

* Added default tab with the label "Uncategorized"

### Removed

* DebugItem.Setings has been removed

### Changed

* Headers now recieve an address string instead of a parent transform

* Debug.Make.Tab is no longer accessible. 
    * Instead, generating buttons automatically creates tabs based on the address provided in the header
